USE [PizzaExpress]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[setor] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tb_Cliente]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[NomeCliente] [varchar](60) NOT NULL,
	[TelefoneCliente] [varchar](18) NULL,
	[Rua] [varchar](30) NULL,
	[Bairro] [varchar](30) NULL,
	[Numero] [varchar](10) NULL,
 CONSTRAINT [PK_Tb_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tb_Funcionario]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_Funcionario](
	[IdFuncionario] [int] NULL,
	[nome] [varchar](100) NULL,
	[telefone] [varchar](50) NULL,
	[senha] [varchar](50) NULL,
	[permissao] [varchar](50) NULL,
	[setor] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tb_Pedido]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_Pedido](
	[NumPedido] [int] IDENTITY(10000,1) NOT NULL,
	[DescPedido] [varchar](50) NOT NULL,
	[DataPedido] [datetime] NOT NULL,
	[PrecoTotal] [money] NOT NULL,
	[TipoPedido] [varchar](20) NOT NULL,
	[StatusPedido] [varchar](50) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdPizza] [int] NULL,
	[IdProduto] [int] NULL,
 CONSTRAINT [PK_Tb_Pedido] PRIMARY KEY CLUSTERED 
(
	[NumPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tb_Pizza]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_Pizza](
	[IdPizza] [int] IDENTITY(1,1) NOT NULL,
	[PrecoPizza] [money] NOT NULL,
	[Tamanho] [varchar](20) NOT NULL,
	[Sabor1] [int] NOT NULL,
	[Sabor2] [int] NULL,
	[Sabor3] [int] NULL,
	[status] [varchar](100) NULL,
 CONSTRAINT [PK_Tb_Pizza] PRIMARY KEY CLUSTERED 
(
	[IdPizza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tb_Produto]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_Produto](
	[IdProduto] [int] IDENTITY(1,1) NOT NULL,
	[NomeProduto] [varchar](50) NOT NULL,
	[DescProduto] [varchar](50) NULL,
	[PrecoProduto] [money] NOT NULL,
 CONSTRAINT [PK_Tb_Produto] PRIMARY KEY CLUSTERED 
(
	[IdProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tb_Sabor]    Script Date: 26/04/2017 14:43:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_Sabor](
	[IdSabor] [int] IDENTITY(1,1) NOT NULL,
	[NomeSabor] [varchar](30) NOT NULL,
	[DescSabor] [varchar](60) NOT NULL,
	[PrecoSabor] [money] NOT NULL,
 CONSTRAINT [PK_Tb_Sabor] PRIMARY KEY CLUSTERED 
(
	[IdSabor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Tb_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Pedido_Tb_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Tb_Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Tb_Pedido] CHECK CONSTRAINT [FK_Tb_Pedido_Tb_Cliente]
GO
ALTER TABLE [dbo].[Tb_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Pedido_Tb_Pedido] FOREIGN KEY([NumPedido])
REFERENCES [dbo].[Tb_Pedido] ([NumPedido])
GO
ALTER TABLE [dbo].[Tb_Pedido] CHECK CONSTRAINT [FK_Tb_Pedido_Tb_Pedido]
GO
ALTER TABLE [dbo].[Tb_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Pedido_Tb_Pizza] FOREIGN KEY([IdPizza])
REFERENCES [dbo].[Tb_Pizza] ([IdPizza])
GO
ALTER TABLE [dbo].[Tb_Pedido] CHECK CONSTRAINT [FK_Tb_Pedido_Tb_Pizza]
GO
ALTER TABLE [dbo].[Tb_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Pedido_Tb_Produto] FOREIGN KEY([IdProduto])
REFERENCES [dbo].[Tb_Produto] ([IdProduto])
GO
ALTER TABLE [dbo].[Tb_Pedido] CHECK CONSTRAINT [FK_Tb_Pedido_Tb_Produto]
GO
ALTER TABLE [dbo].[Tb_Pizza]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Pizza_Tb_Pizza] FOREIGN KEY([IdPizza])
REFERENCES [dbo].[Tb_Pizza] ([IdPizza])
GO
ALTER TABLE [dbo].[Tb_Pizza] CHECK CONSTRAINT [FK_Tb_Pizza_Tb_Pizza]
GO
ALTER TABLE [dbo].[Tb_Pizza]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Pizza_Tb_Sabor] FOREIGN KEY([Sabor1])
REFERENCES [dbo].[Tb_Sabor] ([IdSabor])
GO
ALTER TABLE [dbo].[Tb_Pizza] CHECK CONSTRAINT [FK_Tb_Pizza_Tb_Sabor]
GO
ALTER TABLE [dbo].[Tb_Pizza]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Pizza_Tb_Sabor1] FOREIGN KEY([Sabor2])
REFERENCES [dbo].[Tb_Sabor] ([IdSabor])
GO
ALTER TABLE [dbo].[Tb_Pizza] CHECK CONSTRAINT [FK_Tb_Pizza_Tb_Sabor1]
GO
ALTER TABLE [dbo].[Tb_Pizza]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Pizza_Tb_Sabor2] FOREIGN KEY([Sabor3])
REFERENCES [dbo].[Tb_Sabor] ([IdSabor])
GO
ALTER TABLE [dbo].[Tb_Pizza] CHECK CONSTRAINT [FK_Tb_Pizza_Tb_Sabor2]
GO
INSERT INTO Tb_Cliente (NomeCliente,TelefoneCliente,Rua,Bairro,Numero) VALUES ('Igor','991021','Cidade de deus','Bairro da lapa','21')
INSERT INTO Tb_Sabor (DescSabor, NomeSabor, PrecoSabor) VALUES ('Sabor Português','Portuguesa',2)
INSERT INTO Tb_Produto (DescProduto, NomeProduto, PrecoProduto) VALUES ('Refrigerante','coca',5)