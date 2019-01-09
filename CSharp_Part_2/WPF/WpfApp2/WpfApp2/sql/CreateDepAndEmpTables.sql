CREATE TABLE[dbo].[Departament] (
                                    [ID] INT IDENTITY(1, 1) NOT NULL,
                                    [Name] NVARCHAR(50) NOT NULL,
                                    CONSTRAINT[PK_dbo.Departament] PRIMARY KEY CLUSTERED([Id] ASC)
                                );

CREATE TABLE[dbo].[Employee] (
                                    [ID] INT IDENTITY(1, 1) NOT NULL,
                                    [Name] NVARCHAR(50) NOT NULL,
									[Departament_ID] INT NOT NULL,
                                    CONSTRAINT[PK_dbo.Employee] PRIMARY KEY CLUSTERED([Id] ASC)
                                );