/*
    김포 녹취 통합DB 테스트 환경 - CENTRAL 통합 뷰 생성 스크립트입니다.
    6개 업무 DB에 CENTRAL_2024~2026 UNION ALL 뷰를 생성합니다.
*/

SET NOCOUNT ON;

DECLARE @DatabaseNames TABLE
(
    DbName sysname NOT NULL
);

INSERT INTO @DatabaseNames (DbName)
VALUES
    (N'LucisDB_CC'),
    (N'LucisDB_Car'),
    (N'LucisDB_IPT'),
    (N'LucisDB_BS'),
    (N'LucisDB_JH'),
    (N'LucisDB_Mark');

DECLARE @DbName sysname;
DECLARE @Sql nvarchar(max);

DECLARE db_cursor CURSOR LOCAL FAST_FORWARD FOR
    SELECT DbName FROM @DatabaseNames;

OPEN db_cursor;
FETCH NEXT FROM db_cursor INTO @DbName;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @Sql = N'
USE [' + @DbName + N'];
IF OBJECT_ID(N''dbo.CENTRAL'', N''V'') IS NOT NULL
    DROP VIEW dbo.CENTRAL;

EXEC(N''
CREATE VIEW dbo.CENTRAL AS
    SELECT * FROM dbo.CENTRAL_2024
    UNION ALL
    SELECT * FROM dbo.CENTRAL_2025
    UNION ALL
    SELECT * FROM dbo.CENTRAL_2026
'');

PRINT N''Created view: ' + @DbName + N'.dbo.CENTRAL'';';

    EXEC sys.sp_executesql @Sql;

    FETCH NEXT FROM db_cursor INTO @DbName;
END

CLOSE db_cursor;
DEALLOCATE db_cursor;
GO
