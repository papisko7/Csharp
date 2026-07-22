CREATE VIEW factZoneAlarmEvents AS
SELECT 
    id,
    Event,
    Date,
    Time,
    DATEPART(hour, Time) AS [Hour],
    DATEPART(minute, Time) AS [Minute],
    DATEPART(second, Time) AS [Second],
    Source,
    Destination,
    Transport
FROM ZoneAlarmLog;