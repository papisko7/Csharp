USE HurtowniaLabKK;

IF OBJECT_ID('FK_ZoneAlarmLog_DimDate', 'F') IS NOT NULL ALTER TABLE ZoneAlarmLog DROP CONSTRAINT FK_ZoneAlarmLog_DimDate;
IF OBJECT_ID('FK_ZoneAlarmLog_DimSource', 'F') IS NOT NULL ALTER TABLE ZoneAlarmLog DROP CONSTRAINT FK_ZoneAlarmLog_DimSource;
IF OBJECT_ID('FK_ZoneAlarmLog_DimDestination', 'F') IS NOT NULL ALTER TABLE ZoneAlarmLog DROP CONSTRAINT FK_ZoneAlarmLog_DimDestination;
IF OBJECT_ID('FK_ZoneAlarmLog_DimTransport', 'F') IS NOT NULL ALTER TABLE ZoneAlarmLog DROP CONSTRAINT FK_ZoneAlarmLog_DimTransport;