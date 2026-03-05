-- Create Database
CREATE DATABASE EventDb;
GO

-- Use Database
USE EventDb;
GO

-------------------------------------------------
-- 1. UserInfo Table
-------------------------------------------------
CREATE TABLE UserInfo(
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL,
    Password VARCHAR(20) NOT NULL,

    CONSTRAINT CHK_UserName_Length 
    CHECK (LEN(UserName) BETWEEN 1 AND 50),

    CONSTRAINT CHK_Role 
    CHECK (Role IN ('Admin','Participant')),

    CONSTRAINT CHK_Password_Length 
    CHECK (LEN(Password) BETWEEN 6 AND 20)
);

-------------------------------------------------
-- 2. EventDetails Table
-------------------------------------------------
CREATE TABLE EventDetails(
    EventId INT PRIMARY KEY IDENTITY(1,1),
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description VARCHAR(255) NULL,
    Status VARCHAR(20),

    CONSTRAINT CHK_EventName_Length
    CHECK (LEN(EventName) BETWEEN 1 AND 50),

    CONSTRAINT CHK_EventCategory_Length
    CHECK (LEN(EventCategory) BETWEEN 1 AND 50),

    CONSTRAINT CHK_Event_Status
    CHECK (Status IN ('Active','In-Active'))
);

-------------------------------------------------
-- 3. SpeakersDetails Table
-------------------------------------------------
CREATE TABLE SpeakersDetails(
    SpeakerId INT PRIMARY KEY IDENTITY(1,1),
    SpeakerName VARCHAR(50) NOT NULL,

    CONSTRAINT CHK_SpeakerName_Length
    CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);

-------------------------------------------------
-- 4. SessionInfo Table
-------------------------------------------------
CREATE TABLE SessionInfo(
    SessionId INT PRIMARY KEY IDENTITY(1,1),
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,
    Description VARCHAR(255) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(255),

    CONSTRAINT CHK_SessionTitle_Length
    CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),

    CONSTRAINT FK_Event_Session
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Speaker_Session
    FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);

-------------------------------------------------
-- 5. ParticipantEventDetails Table
-------------------------------------------------
CREATE TABLE ParticipantEventDetails(
    Id INT PRIMARY KEY IDENTITY(1,1),
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT,

    CONSTRAINT FK_User_Participant
    FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),

    CONSTRAINT FK_Event_Participant
    FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Session_Participant
    FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);