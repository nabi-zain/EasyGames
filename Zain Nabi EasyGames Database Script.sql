CREATE DATABASE dbZainNabiEasyGames
GO

USE dbZainNabiEasyGames
GO

CREATE TABLE TransactionType
(
	TransactionTypeID smallint primary key identity(1,1) not null,
	TransactionTypeName nvarchar(50) not null
)

INSERT INTO TransactionType(TransactionTypeName) VALUES('Debit')
INSERT INTO TransactionType(TransactionTypeName) VALUES('Credit')


CREATE TABLE Client
(
	ClientID int primary key identity(1,1) not null,
	[Name] nvarchar(50) not null,
	Surname nvarchar(50) not null,
	ClientBalance decimal(18,2) not null
)


insert into Client([Name],Surname,ClientBalance) values ('Zain','Nabi',1505.00)
insert into Client([Name],Surname,ClientBalance) values ('Altaaf','Hassan',20500.00)
insert into Client([Name],Surname,ClientBalance) values ('Karim','Benzema',12117.00)



CREATE TABLE [Transaction]
(
	TransactionID bigint primary key identity(1,1),
	Amount decimal(18,2) not null,
	TransactionTypeID smallint not null,
	ClientID int not null,
	Comment nvarchar(100) null
)


insert into [Transaction](Amount, TransactionTypeID, ClientID) values(-500,1,1)
insert into [Transaction](Amount, TransactionTypeID, ClientID) values(-780.5,2,2)
insert into [Transaction](Amount, TransactionTypeID, ClientID) values(780.05,1,3)
insert into [Transaction](Amount, TransactionTypeID, ClientID) values(780.05,2,3)
insert into [Transaction](Amount, TransactionTypeID, ClientID) values(780.05,2,3)
insert into [Transaction](Amount, TransactionTypeID, ClientID) values(780.05,2,3)
insert into [Transaction](Amount, TransactionTypeID, ClientID) values(780.05,2,3)
insert into [Transaction](Amount, TransactionTypeID, ClientID) values(780.05,2,3)


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'myproc') AND type in (N'P', N'PC'))
  DROP PROCEDURE [dbo].spGETClientTransactions
GO
create  procedure spGETClientTransactions
@ClientID int
as
begin
	select 
		c.Name,
		c.Surname,
		t.Amount,
		tt.transactiontypename,
		t.comment,
		t.transactionID,
		c.ClientID
	from Client c
	left join [Transaction] t on t.clientID = c.ClientID
	left join [TransactionType] tt on tt.TransactionTypeID = t.TransactionTypeID
	where c.clientID = @ClientID
END
go


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'myproc') AND type in (N'P', N'PC'))
  DROP PROCEDURE [dbo].spUpdateComment
GO
Create  procedure spUpdateComment
@TransactionID int,
@Comment varchar(255)
AS
Begin
	update [Transaction]
	set comment = @Comment
	where TransactionID = @TransactionID
End
go

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'myproc') AND type in (N'P', N'PC'))
  DROP PROCEDURE [dbo].spGETTransactions
GO
create  procedure spGETTransactions
@transactionID int
as
begin
	select 
		c.Name,
		c.Surname,
		t.Amount,
		tt.transactiontypename,
		t.comment,
		t.transactionID,
		c.ClientID
	from Client c
	left join [Transaction] t on t.clientID = c.ClientID
	left join [TransactionType] tt on tt.TransactionTypeID = t.TransactionTypeID
	where t.TransactionID = @transactionID
END
go

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'myproc') AND type in (N'P', N'PC'))
  DROP PROCEDURE [dbo].InsertNewTransaction
GO
create  procedure InsertNewTransaction
	@Amount decimal(18,2),
	@TransactionTypeID int,
	@ClientID int
As 
begin
	insert into [Transaction](Amount, TransactionTypeID, ClientID)
		values(@Amount, @TransactionTypeID, @ClientID)
end
go


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'myproc') AND type in (N'P', N'PC'))
  DROP PROCEDURE [dbo].spUpdateClientBalance
GO
CreatE  procedure spUpdateClientBalance
@ClientID int,
@Amount varchar(255)
AS
Begin
	update Client
	set ClientBalance = @Amount
	where ClientID = @ClientID
End
go