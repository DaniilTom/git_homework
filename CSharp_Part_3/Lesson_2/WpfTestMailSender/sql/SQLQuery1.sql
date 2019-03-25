CREATE TABLE[dbo].[Emails] (
                                    [Id] INT IDENTITY(1, 1) NOT NULL,
                                    [Email] NVARCHAR(MAX) NOT NULL,
									[Name] NVARCHAR(MAX) NOT NULL,
                                    CONSTRAINT[PK_dbo.Emails] PRIMARY KEY CLUSTERED([Id] ASC)
                                );

INSERT INTO Emails("Email", "Name") VALUES ( 'asdf@mail.ru', 'Asdf Tuikjn');
INSERT INTO Emails("Email", "Name") VALUES ( 'sdf@gmail.ru', 'Hnf Jjn');
INSERT INTO Emails("Email", "Name") VALUES ( 'df@ymail.ru', 'Plk Hoeop');
INSERT INTO Emails("Email", "Name") VALUES ( 'sasdf@fmail.ru', 'Nsdj Ihds');
INSERT INTO Emails("Email", "Name") VALUES ( 'hjkasdf@mail.ru', 'Efdg Ookghn');
INSERT INTO Emails("Email", "Name") VALUES ( 'lkasdf@mail.ru', 'Rgds Tuhjdfdn');
INSERT INTO Emails("Email", "Name") VALUES ( 'nbasdf@mail.ru', 'Af Bgdcx');
INSERT INTO Emails("Email", "Name") VALUES ( 'vbasdf@mail.ru', 'YRdgf DGchdb');
INSERT INTO Emails("Email", "Name") VALUES ( '342asdf@mail.ru', 'IUnjkf Cjkf');