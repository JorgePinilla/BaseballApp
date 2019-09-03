create database BaseballApp;

-- run the following after database has been created
use BaseballApp;

create table Team(
	Id int not null,
	Name nvarchar(100) not null,
	VenueId int,
	TeamCode nvarchar(3),
	FileCode nvarchar(3),
	Abbreviation nvarchar(3),
	TeamName nvarchar(100),
	LocationName nvarchar(100),
	FirstYearOfPlay int,
	LeagueId int not null,
	DivisionId int not null,
	SportId int not null,
	ShortName nvarchar(50),
	SpringLeagueId int,
	AllStarStatus nvarchar(1),
	Active bit,
	Primary Key (Id)
)

create table Venue(
	Id int not null,
	Name nvarchar(100) not null,
	Primary Key (Id)
)

create table League(
	Id int not null,
	Name nvarchar(100) not null,
	Abbreviation nvarchar(3),
	IsSpringLeague bit,
	Primary Key (Id)
)

create table Division(
	Id int not null,
	Name nvarchar(100) not null,
	Primary Key (Id)
)

create table Sport(
	Id int not null,
	Name nvarchar(100) not null,
	Primary Key (Id)
)

create table Person(
	Id int not null,
	FullName nvarchar(60) not null,
	FirstName nvarchar(30) not null,
	MiddleName nvarchar(30),
	LastName nvarchar(30) not null,
	PrimaryNumber int,
	BirthDate date,
	Age int,
	BirthCity nvarchar(50),
	BirthStateProvince nvarchar(30),
	BirthCountry nvarchar(50),
	Height nvarchar(10),
	Weight int,
	Active bit,
	PositionCode nvarchar(10) not null,
	NickName nvarchar(20),
	Gender nvarchar(1) not null,
	IsPlayer bit,
	IsVerified bit,
	DraftYear nvarchar(4),
	MLBDebutDate date,
	BatSide nvarchar(10),
	PitchHand nvarchar(10),
	Primary Key (Id)
)

create table Stat(
	PersonId int not null,
	TeamId int not null,
	StatGroup nvarchar(10) not null,
	Season nvarchar(4) not null,
	PositionCode nvarchar(10) not null,
	Name nvarchar(100),
	--General stats
	GamesPlayed int,
	GamesStarted int, -- not in hitting
	Runs int,         -- not in fielding
	HomeRuns int,     -- not in fielding
	StrikeOuts int,   -- not in fielding
	Hits int,         -- not in fielding
	AVG nvarchar(5), -- not in fielding
	OBP nvarchar(5), -- not in fielding
	SLG nvarchar(5), -- not in fielding
	OPS nvarchar(5), -- not in fielding
	StolenBasePercentage nvarchar(5), -- not in fielding
	--Pitching stats
	ERA nvarchar(5), 
	Wins int,
	Losses int,
	Whip nvarchar(5),
	StrikePercentage nvarchar(5),
	WinPercentage nvarchar(5),
	GamesFinished int,
	StrikeOutWalkRatio nvarchar(5),
	--Hitting Stats
	Doubles int,
	Triples int,
	RBI int,
	BABIP nvarchar(5),
	--Fielding Stats
	Assists int,
	PutOuts int,
	Errors int,
	Chances int,
	Fielding nvarchar(5),
	Primary Key (PersonId, TeamId, StatGroup, Season, PositionCode)
)

create table Roster(
	PersonId int not null,
	TeamId int not null,
	Season nvarchar(4),
	FullName nvarchar(50) not null,
	JerseyNumber int not null,
	BirthDate date,
	BirthCountry nvarchar(50),
	Height nvarchar(10),
	Weight int,
	PositionCode nvarchar(10) not null,
	StatGroup nvarchar(10) not null,
	Status nvarchar(10) not null,
	Primary Key (PersonId)
)

create table Position(
	Code nvarchar(10) not null,
	Name nvarchar(20) not null,
	Type nvarchar(20) not null,
	Abbreviation nvarchar(3),
	Primary Key (Code)
)