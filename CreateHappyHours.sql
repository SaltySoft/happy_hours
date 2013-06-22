USE [master]
GO
/****** Object:  Database [HappyHours]    Script Date: 22/06/2013 21:07:51 ******/
CREATE DATABASE [HappyHours] ON  

GO
ALTER DATABASE [HappyHours] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HappyHours].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HappyHours] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HappyHours] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HappyHours] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HappyHours] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HappyHours] SET ARITHABORT OFF 
GO
ALTER DATABASE [HappyHours] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HappyHours] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [HappyHours] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HappyHours] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HappyHours] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HappyHours] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HappyHours] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HappyHours] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HappyHours] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HappyHours] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HappyHours] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HappyHours] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HappyHours] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HappyHours] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HappyHours] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HappyHours] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HappyHours] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HappyHours] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HappyHours] SET  MULTI_USER 
GO
ALTER DATABASE [HappyHours] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HappyHours] SET DB_CHAINING OFF 
GO
USE [HappyHours]
GO
/****** Object:  Table [dbo].[T_Cocktail]    Script Date: 22/06/2013 21:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Cocktail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[difficulty] [int] NOT NULL,
	[duration] [int] NOT NULL,
	[creator_id] [int] NOT NULL,
	[description] [nvarchar](200) NOT NULL,
	[recipe] [nvarchar](200) NOT NULL,
	[picture_url] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_T_Cocktail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_CocktailsIngredients]    Script Date: 22/06/2013 21:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CocktailsIngredients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cocktail_id] [int] NOT NULL,
	[ingredient_id] [int] NOT NULL,
 CONSTRAINT [PK_T_CocktailsIngredients] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Favorite]    Script Date: 22/06/2013 21:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Favorite](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cocktail_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_T_Favorite] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Ingredient]    Script Date: 22/06/2013 21:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Ingredient](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_T_Ingredient] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_User]    Script Date: 22/06/2013 21:07:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[admin] [int] NOT NULL,
 CONSTRAINT [PK_T_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[T_Cocktail]  WITH CHECK ADD  CONSTRAINT [FK_T_Cocktail_T_User] FOREIGN KEY([creator_id])
REFERENCES [dbo].[T_User] ([id])
GO
ALTER TABLE [dbo].[T_Cocktail] CHECK CONSTRAINT [FK_T_Cocktail_T_User]
GO
ALTER TABLE [dbo].[T_CocktailsIngredients]  WITH CHECK ADD  CONSTRAINT [FK_T_CocktailsIngredients_T_Cocktail] FOREIGN KEY([cocktail_id])
REFERENCES [dbo].[T_Cocktail] ([id])
GO
ALTER TABLE [dbo].[T_CocktailsIngredients] CHECK CONSTRAINT [FK_T_CocktailsIngredients_T_Cocktail]
GO
ALTER TABLE [dbo].[T_CocktailsIngredients]  WITH CHECK ADD  CONSTRAINT [FK_T_CocktailsIngredients_T_Ingredient] FOREIGN KEY([ingredient_id])
REFERENCES [dbo].[T_Ingredient] ([id])
GO
ALTER TABLE [dbo].[T_CocktailsIngredients] CHECK CONSTRAINT [FK_T_CocktailsIngredients_T_Ingredient]
GO
ALTER TABLE [dbo].[T_Favorite]  WITH CHECK ADD  CONSTRAINT [FK_T_Favorite_T_Cocktail] FOREIGN KEY([cocktail_id])
REFERENCES [dbo].[T_Cocktail] ([id])
GO
ALTER TABLE [dbo].[T_Favorite] CHECK CONSTRAINT [FK_T_Favorite_T_Cocktail]
GO
ALTER TABLE [dbo].[T_Favorite]  WITH CHECK ADD  CONSTRAINT [FK_T_Favorite_T_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[T_User] ([id])
GO
ALTER TABLE [dbo].[T_Favorite] CHECK CONSTRAINT [FK_T_Favorite_T_User]
GO
USE [master]
GO
ALTER DATABASE [HappyHours] SET  READ_WRITE 
GO
