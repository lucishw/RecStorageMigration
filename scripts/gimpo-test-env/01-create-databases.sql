/*
    김포 녹취 통합DB 테스트 환경 - 7개 데이터베이스 생성 스크립트입니다.
    Collation: Korean_Wansung_CI_AS
*/

SET NOCOUNT ON;

IF DB_ID(N'LucisDB_CC') IS NULL
BEGIN
    CREATE DATABASE [LucisDB_CC]
    COLLATE Korean_Wansung_CI_AS;
    PRINT N'Created database: LucisDB_CC';
END
ELSE
    PRINT N'Database already exists: LucisDB_CC';
GO

IF DB_ID(N'LucisDB_Car') IS NULL
BEGIN
    CREATE DATABASE [LucisDB_Car]
    COLLATE Korean_Wansung_CI_AS;
    PRINT N'Created database: LucisDB_Car';
END
ELSE
    PRINT N'Database already exists: LucisDB_Car';
GO

IF DB_ID(N'LucisDB_IPT') IS NULL
BEGIN
    CREATE DATABASE [LucisDB_IPT]
    COLLATE Korean_Wansung_CI_AS;
    PRINT N'Created database: LucisDB_IPT';
END
ELSE
    PRINT N'Database already exists: LucisDB_IPT';
GO

IF DB_ID(N'LucisDB_BS') IS NULL
BEGIN
    CREATE DATABASE [LucisDB_BS]
    COLLATE Korean_Wansung_CI_AS;
    PRINT N'Created database: LucisDB_BS';
END
ELSE
    PRINT N'Database already exists: LucisDB_BS';
GO

IF DB_ID(N'LucisDB_JH') IS NULL
BEGIN
    CREATE DATABASE [LucisDB_JH]
    COLLATE Korean_Wansung_CI_AS;
    PRINT N'Created database: LucisDB_JH';
END
ELSE
    PRINT N'Database already exists: LucisDB_JH';
GO

IF DB_ID(N'LucisDB_Mark') IS NULL
BEGIN
    CREATE DATABASE [LucisDB_Mark]
    COLLATE Korean_Wansung_CI_AS;
    PRINT N'Created database: LucisDB_Mark';
END
ELSE
    PRINT N'Database already exists: LucisDB_Mark';
GO

IF DB_ID(N'LucisDB_Media') IS NULL
BEGIN
    CREATE DATABASE [LucisDB_Media]
    COLLATE Korean_Wansung_CI_AS;
    PRINT N'Created database: LucisDB_Media';
END
ELSE
    PRINT N'Database already exists: LucisDB_Media';
GO
