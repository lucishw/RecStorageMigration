/*
    김포 녹취 통합DB 테스트 환경 - LucisDB_Media CENTRAL 단일 테이블 생성 스크립트입니다.
    매체변환 DB는 연도 분할 없이 CENTRAL 테이블 1개만 사용합니다.
*/

SET NOCOUNT ON;

USE [LucisDB_Media];
GO

IF OBJECT_ID(N'dbo.CENTRAL', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CENTRAL
    (
        [FILENAME]        [varchar](22)    NOT NULL,
        [SERVERNAME]      [varchar](20)    NOT NULL,
        [CHANNEL]         [int]            NULL,
        [CHANNELNAME]     [varchar](40)    NULL,
        [DATE]            [datetime]       NULL,
        [TIME]            [datetime]       NULL,
        [DURATION]        [datetime]       NULL,
        [REFERENCE]       [varchar](20)    NULL,
        [LOCATION]        [varchar](24)    NULL,
        [ARCHIVEFLAG]     [tinyint]        NULL,
        [DIALEDNUMBER]    [varchar](40)    NULL,
        [AGENT]           [varchar](20)    NULL,
        [AGENTNAME]       [varchar](40)    NULL,
        [MEMO]            [tinyint]        NULL,
        [RECNUM]          [money]          NULL,
        [CALLERNAME]      [varchar](40)    NULL,
        [CALLERNUMBER]    [varchar](40)    NULL,
        [CALLDIRECTION]   [char](1)        NULL,
        [CALLINDEX]       [varchar](20)    NULL,
        [SCHEDULE]        [char](1)        NULL,
        [GROUPID]         [varchar](15)    NULL,
        [GROUPNAME]       [varchar](30)    NULL,
        [STATION]         [varchar](10)    NULL,
        [TRUNKNUMBER]     [varchar](15)    NULL,
        [ROUTE]           [varchar](15)    NULL,
        [SPARE01]         [varchar](20)    NULL,
        [EVALUATE]        [varchar](4)     NULL,
        [RECTYPE]         [int]            NULL,
        [STARTED]         [datetime]       NULL,
        [ENDED]           [datetime]       NULL,
        [TERMREASON]      [varchar](4)     NULL,
        [M_INDEX]         [varchar](50)    NULL,
        [SEGMENT]         [tinyint]        NULL,
        [MINRECORDTIME]   [int]            NULL,
        [UPLOADSTATUS]    [int]            NULL,
        [MEMBER]          [int]            NULL,
        [MEMBERNAME]      [int]            NULL,
        [TRUNKGROUP]      [varchar](20)    NULL,
        [BUFFER01]        [varchar](50)    NULL,
        [BUFFER02]        [varchar](50)    NULL,
        [BUFFER03]        [varchar](50)    NULL,
        [BUFFER04]        [varchar](50)    NULL,
        [BUFFER05]        [varchar](50)    NULL,
        [BUFFER06]        [varchar](50)    NULL,
        [BUFFER07]        [varchar](50)    NULL,
        [BUFFER08]        [varchar](50)    NULL,
        [BUFFER09]        [varchar](50)    NULL,
        [BUFFER10]        [varchar](50)    NULL,
        [BUFFER11]        [varchar](50)    NULL,
        [BUFFER12]        [varchar](50)    NULL,
        [BUFFER13]        [varchar](50)    NULL,
        [BUFFER14]        [varchar](50)    NULL,
        [BUFFER15]        [varchar](50)    NULL,
        [BUFFER16]        [varchar](50)    NULL,
        [BUFFER17]        [varchar](50)    NULL,
        [BUFFER18]        [varchar](50)    NULL,
        [BUFFER19]        [varchar](1024)  NULL,
        [BUFFER20]        [varchar](1024)  NULL,
        [READSTATUS]      [smallint]       NULL
    );

    PRINT N'Created table: LucisDB_Media.dbo.CENTRAL';
END
ELSE
    PRINT N'Table already exists: LucisDB_Media.dbo.CENTRAL';
GO
