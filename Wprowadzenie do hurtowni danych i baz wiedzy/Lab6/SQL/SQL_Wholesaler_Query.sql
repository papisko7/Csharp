USE HurtowniaLabKK;

-------------------------------------------------------------------------
-- STEP 1: CLEANING UP OLD TABLES AND RELATIONS
-------------------------------------------------------------------------
IF OBJECT_ID('FK_ZoneAlarmLog_DimDate', 'F') IS NOT NULL ALTER TABLE ZoneAlarmLog DROP CONSTRAINT FK_ZoneAlarmLog_DimDate;
IF OBJECT_ID('FK_ZoneAlarmLog_DimSource', 'F') IS NOT NULL ALTER TABLE ZoneAlarmLog DROP CONSTRAINT FK_ZoneAlarmLog_DimSource;
IF OBJECT_ID('FK_ZoneAlarmLog_DimDestination', 'F') IS NOT NULL ALTER TABLE ZoneAlarmLog DROP CONSTRAINT FK_ZoneAlarmLog_DimDestination;
IF OBJECT_ID('FK_ZoneAlarmLog_DimTransport', 'F') IS NOT NULL ALTER TABLE ZoneAlarmLog DROP CONSTRAINT FK_ZoneAlarmLog_DimTransport;

IF OBJECT_ID('FK_DimDate_Month', 'F') IS NOT NULL ALTER TABLE DimDate DROP CONSTRAINT FK_DimDate_Month;
IF OBJECT_ID('FK_DimDate_DayOfWeek', 'F') IS NOT NULL ALTER TABLE DimDate DROP CONSTRAINT FK_DimDate_DayOfWeek;

IF OBJECT_ID('DimDate', 'U') IS NOT NULL DROP TABLE DimDate;
IF OBJECT_ID('DimSource', 'U') IS NOT NULL DROP TABLE DimSource;
IF OBJECT_ID('DimDestination', 'U') IS NOT NULL DROP TABLE DimDestination;
IF OBJECT_ID('DimTransport', 'U') IS NOT NULL DROP TABLE DimTransport;
IF OBJECT_ID('DimDateMonthName', 'U') IS NOT NULL DROP TABLE DimDateMonthName;
IF OBJECT_ID('DimDateDayOfWeek', 'U') IS NOT NULL DROP TABLE DimDateDayOfWeek;
GO

-------------------------------------------------------------------------
-- STEP 2: CREATING MANUAL DICTIONARY TABLES
-------------------------------------------------------------------------
CREATE TABLE DimDateMonthName (
    MonthNum INT PRIMARY KEY,
    MonthName VARCHAR(20)
);
INSERT INTO DimDateMonthName (MonthNum, MonthName) VALUES 
(1, 'January'), (2, 'February'), (3, 'March'), (4, 'April'), (5, 'May'), (6, 'June'),
(7, 'July'), (8, 'August'), (9, 'September'), (10, 'October'), (11, 'November'), (12, 'December');

CREATE TABLE DimDateDayOfWeek (
    DayOfWeekNum INT PRIMARY KEY,
    DayOfWeekName VARCHAR(20)
);
INSERT INTO DimDateDayOfWeek (DayOfWeekNum, DayOfWeekName) VALUES 
(1, 'Sunday'), (2, 'Monday'), (3, 'Tuesday'), (4, 'Wednesday'), (5, 'Thursday'), (6, 'Friday'), (7, 'Saturday');
GO

-------------------------------------------------------------------------
-- STEP 3: EXTRACTION AND TRANSFORMATION OF DATA FROM THE FACT TABLE
-------------------------------------------------------------------------

-- 1. DimDate
SELECT DISTINCT 
    [Date] AS DateKey,
    DATEPART(year, [Date]) AS [Year],
    DATEPART(month, [Date]) AS [Month],
    DATEPART(day, [Date]) AS [Day],
    DATEPART(weekday, [Date]) AS [DayOfWeek],
    DATEPART(quarter, [Date]) AS [Quarter]
INTO DimDate
FROM ZoneAlarmLog
WHERE [Date] IS NOT NULL;
GO

ALTER TABLE DimDate ALTER COLUMN DateKey DATETIME NOT NULL;
GO
ALTER TABLE DimDate ADD PRIMARY KEY (DateKey);
GO

-- 2. DimSource
SELECT DISTINCT 
    [Source] AS SourceKey,
    CASE 
        WHEN CHARINDEX(':', [Source]) = 0 THEN [Source]
        ELSE LEFT([Source], CHARINDEX(':', [Source]) - 1) 
    END AS [Source],
    CASE 
        WHEN CHARINDEX(':', [Source]) = 0 THEN NULL
        ELSE SUBSTRING([Source], CHARINDEX(':', [Source]) + 1, LEN([Source])) 
    END AS [SourcePort],
    CASE 
        WHEN CHARINDEX(':', [Source]) = 0 THEN 'App' 
        ELSE 'IP' 
    END AS [SourceType]
INTO DimSource
FROM ZoneAlarmLog
WHERE [Source] IS NOT NULL;
GO

ALTER TABLE DimSource ALTER COLUMN SourceKey VARCHAR(200) NOT NULL;
GO
ALTER TABLE DimSource ADD PRIMARY KEY (SourceKey);
GO

-- 3. DimDestination
SELECT DISTINCT 
    [Destination] AS DestinationKey,
    CASE 
        WHEN CHARINDEX(':', [Destination]) = 0 THEN [Destination]
        ELSE LEFT([Destination], CHARINDEX(':', [Destination]) - 1) 
    END AS [Destination],
    CASE 
        WHEN CHARINDEX(':', [Destination]) = 0 THEN NULL
        ELSE SUBSTRING([Destination], CHARINDEX(':', [Destination]) + 1, LEN([Destination])) 
    END AS [DestinationPort],
    CASE 
        WHEN CHARINDEX(':', [Destination]) = 0 THEN 'App' 
        ELSE 'IP' 
    END AS [DestinationType]
INTO DimDestination
FROM ZoneAlarmLog
WHERE [Destination] IS NOT NULL;
GO

ALTER TABLE DimDestination ALTER COLUMN DestinationKey VARCHAR(200) NOT NULL;
GO
ALTER TABLE DimDestination ADD PRIMARY KEY (DestinationKey);
GO

-- 4. DimTransport
SELECT DISTINCT 
    [Transport] AS TransportKey,
    CASE 
        WHEN [Transport] LIKE '% %' THEN LEFT([Transport], CHARINDEX(' ', [Transport]) - 1)
        ELSE [Transport] 
    END AS [Transport],
    CASE 
        WHEN [Transport] LIKE 'ICMP (type:%' THEN SUBSTRING([Transport], CHARINDEX('type:', [Transport]) + 5, CHARINDEX('/', [Transport]) - CHARINDEX('type:', [Transport]) - 5)
        ELSE NULL 
    END AS [TransportType],
    CASE 
        WHEN [Transport] LIKE '%subtype:%' THEN SUBSTRING([Transport], CHARINDEX('subtype:', [Transport]) + 8, CHARINDEX(')', [Transport]) - CHARINDEX('subtype:', [Transport]) - 8)
        ELSE NULL 
    END AS [TransportSubType],
    CASE 
        WHEN [Transport] LIKE 'TCP (flags:%' THEN SUBSTRING([Transport], CHARINDEX('flags:', [Transport]) + 6, CHARINDEX(')', [Transport]) - CHARINDEX('flags:', [Transport]) - 6)
        ELSE NULL 
    END AS [TransportFlags]
INTO DimTransport
FROM ZoneAlarmLog
WHERE [Transport] IS NOT NULL;
GO

ALTER TABLE DimTransport ALTER COLUMN TransportKey VARCHAR(200) NOT NULL;
GO
ALTER TABLE DimTransport ADD PRIMARY KEY (TransportKey);
GO

-------------------------------------------------------------------------
-- STEP 4: CREATING RELATIONS (FOREIGN KEYS)
-------------------------------------------------------------------------
ALTER TABLE ZoneAlarmLog ALTER COLUMN [Source] VARCHAR(200);
ALTER TABLE ZoneAlarmLog ALTER COLUMN [Destination] VARCHAR(200);
ALTER TABLE ZoneAlarmLog ALTER COLUMN [Transport] VARCHAR(200);
GO

ALTER TABLE DimDate ADD CONSTRAINT FK_DimDate_Month FOREIGN KEY ([Month]) REFERENCES DimDateMonthName(MonthNum);
ALTER TABLE DimDate ADD CONSTRAINT FK_DimDate_DayOfWeek FOREIGN KEY ([DayOfWeek]) REFERENCES DimDateDayOfWeek(DayOfWeekNum);

ALTER TABLE ZoneAlarmLog ADD CONSTRAINT FK_ZoneAlarmLog_DimDate FOREIGN KEY ([Date]) REFERENCES DimDate(DateKey);
ALTER TABLE ZoneAlarmLog ADD CONSTRAINT FK_ZoneAlarmLog_DimSource FOREIGN KEY ([Source]) REFERENCES DimSource(SourceKey);
ALTER TABLE ZoneAlarmLog ADD CONSTRAINT FK_ZoneAlarmLog_DimDestination FOREIGN KEY ([Destination]) REFERENCES DimDestination(DestinationKey);
ALTER TABLE ZoneAlarmLog ADD CONSTRAINT FK_ZoneAlarmLog_DimTransport FOREIGN KEY ([Transport]) REFERENCES DimTransport(TransportKey);
GO

PRINT 'Data warehouse has been successfully created!';