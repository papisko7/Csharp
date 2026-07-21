ALTER VIEW factZoneAlarmEvents AS
SELECT 
    id,
    Event,
    Date,
    Time,
    DATEPART(hour, Time) AS [Hour],
    -- Poniżej dodajemy naszą nową kolumnę z grupami (zmianami):
    CASE 
        WHEN DATEPART(hour, Time) >= 0 AND DATEPART(hour, Time) <= 7 THEN '1. 0-7 - zmiana 1'
        WHEN DATEPART(hour, Time) >= 8 AND DATEPART(hour, Time) <= 16 THEN '2. 8-16 - zmiana 2'
        WHEN DATEPART(hour, Time) >= 17 AND DATEPART(hour, Time) <= 23 THEN '3. 17-23 - zmiana 3'
    END AS Hour_group,
    DATEPART(minute, Time) AS [Minute],
    DATEPART(second, Time) AS [Second],
    Source,
    Destination,
    Transport
FROM ZoneAlarmLog;