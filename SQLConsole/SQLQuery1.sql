IF NOT EXISTS (SELECT Id FROM Address WHERE Address = 'Hidingeby')
	IF NOT EXISTS (SELECT Id FROM Address)
		INSERT INTO Address VALUES ('Hidingeby', 'Örebro', 72192)
ELSE
	PRINT 'EXISTS'

