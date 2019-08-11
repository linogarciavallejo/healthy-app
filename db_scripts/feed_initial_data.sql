
DECLARE @UserId AS INT
INSERT INTO [Users] 
VALUES 
('Lino Garcia Vallejo', 
 'Guatemala City', 
 'GT', 
 'lino.garciavallejo@outlook.com',
 '1973-06-07'
 )
SET @UserId = SCOPE_IDENTITY()

INSERT INTO [Event_Types]
VALUES (1, 'Water ingestion')
INSERT INTO [Event_Types]
VALUES (2, 'Commute walk')


INSERT INTO [Weight_Monitoring]
VALUES
( @UserId,
  '2019-08-01 6:30:00',
  75)

INSERT INTO [Healthy_Events]
VALUES
( @UserId,
  '2019-08-05 6:30:00',
  1,
  300,
  NULL,
  NULL,
  NULL,
  10)

INSERT INTO [Healthy_Events]
VALUES
( @UserId,
  '2019-08-06 6:30:00',
  1,
  200,
  NULL,
  NULL,
  NULL,
  8)

INSERT INTO [Healthy_Events]
VALUES
( @UserId,
  '2019-08-06 6:30:00',
  2,
  NULL,
  2.8,
  160,
  0.5,
  7)

INSERT INTO [Healthy_Events]
VALUES
( @UserId,
  '2019-08-10 7:30:00',
  1,
  300,
  NULL,
  NULL,
  NULL,
  10)

INSERT INTO [Healthy_Events]
VALUES
( @UserId,
  '2019-08-10 9:30:00',
  2,
  NULL,
  4.5,
  310,
  0.8,
  8)
