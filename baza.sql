USE [master]
GO
/****** Object:  Database [E-Evidencija]    Script Date: 5/17/2024 5:42:01 AM ******/
CREATE DATABASE [E-Evidencija]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'E-Evidencija', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\E-Evidencija.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'E-Evidencija_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\E-Evidencija_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [E-Evidencija] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [E-Evidencija].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [E-Evidencija] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [E-Evidencija] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [E-Evidencija] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [E-Evidencija] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [E-Evidencija] SET ARITHABORT OFF 
GO
ALTER DATABASE [E-Evidencija] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [E-Evidencija] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [E-Evidencija] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [E-Evidencija] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [E-Evidencija] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [E-Evidencija] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [E-Evidencija] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [E-Evidencija] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [E-Evidencija] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [E-Evidencija] SET  DISABLE_BROKER 
GO
ALTER DATABASE [E-Evidencija] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [E-Evidencija] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [E-Evidencija] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [E-Evidencija] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [E-Evidencija] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [E-Evidencija] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [E-Evidencija] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [E-Evidencija] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [E-Evidencija] SET  MULTI_USER 
GO
ALTER DATABASE [E-Evidencija] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [E-Evidencija] SET DB_CHAINING OFF 
GO
ALTER DATABASE [E-Evidencija] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [E-Evidencija] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [E-Evidencija] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [E-Evidencija] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [E-Evidencija] SET QUERY_STORE = ON
GO
ALTER DATABASE [E-Evidencija] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [E-Evidencija]
GO
/****** Object:  Table [dbo].[evidentiran_mjesec]    Script Date: 5/17/2024 5:42:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[evidentiran_mjesec](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pocetak_mjeseca] [date] NOT NULL,
	[zavrsetak_mjeseca] [date] NOT NULL,
 CONSTRAINT [PK__evidenti__3213E83F9868B05F] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[evidentirano_vrijeme]    Script Date: 5/17/2024 5:42:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[evidentirano_vrijeme](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[datum] [date] NOT NULL,
	[pocetak_rada] [time](7) NOT NULL,
	[zavrsetak_rada] [time](7) NOT NULL,
	[sati_zastoja_od] [time](7) NULL,
	[sati_zastoja_do] [time](7) NULL,
	[opis] [nvarchar](255) NOT NULL,
	[evidentiran_mjesec_id] [int] NULL,
 CONSTRAINT [PK__evidenti__3213E83FEB4EDED8] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[logs]    Script Date: 5/17/2024 5:42:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[logs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[action] [text] NOT NULL,
	[user_id] [int] NULL,
	[time_of_action] [datetime] NOT NULL,
	[state] [nvarchar](255) NULL,
	[ip_address] [nvarchar](15) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[radna_smjena_dani]    Script Date: 5/17/2024 5:42:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[radna_smjena_dani](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_radna_smjena] [int] NOT NULL,
	[datum] [date] NOT NULL,
 CONSTRAINT [PK__radna_sm__3213E83FC9169469] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[radna_smjena_evidencija_radnika]    Script Date: 5/17/2024 5:42:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[radna_smjena_evidencija_radnika](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_radna_smjena_radnici] [int] NOT NULL,
	[naslov_posla] [nvarchar](255) NOT NULL,
	[opis_posla] [text] NOT NULL,
	[pocetak_rada] [time](7) NOT NULL,
	[zavrsetak_rada] [time](7) NOT NULL,
	[sati_zastoja] [int] NOT NULL,
	[evidentirano] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK__radna_sm__3213E83FA56C2593] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[radna_smjena_radnici]    Script Date: 5/17/2024 5:42:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[radna_smjena_radnici](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_user_information] [int] NOT NULL,
	[id_radna_smjena_dani] [int] NOT NULL,
 CONSTRAINT [PK__radna_sm__3213E83FEE5EC0E3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[radna_smjene]    Script Date: 5/17/2024 5:42:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[radna_smjene](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[start_time] [time](7) NOT NULL,
	[end_time] [time](7) NOT NULL,
	[posebni_dan] [bit] NULL,
	[datum_za_posebni_dan] [date] NULL,
 CONSTRAINT [PK__radna_sm__3213E83F34E91E23] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[radnik_placa]    Script Date: 5/17/2024 5:42:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[radnik_placa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_evidentiranog_mjeseca] [int] NOT NULL,
	[id_radnik] [int] NOT NULL,
	[je_placen] [bit] NOT NULL,
 CONSTRAINT [PK__radnik_p__3213E83F5855637F] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tvrtka_config]    Script Date: 5/17/2024 5:42:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tvrtka_config](
	[vise_smjenski_rad] [bit] NOT NULL,
	[automatsko_registriranje_korisnika] [bit] NOT NULL,
	[automatski_posalji_evidenciju_knjigovodi] [bit] NOT NULL,
	[ime_tvrtke] [nvarchar](255) NOT NULL,
	[adresa_tvrtke] [nvarchar](255) NOT NULL,
	[grad_tvrtke] [nvarchar](255) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_information]    Script Date: 5/17/2024 5:42:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_information](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ime] [nvarchar](255) NOT NULL,
	[prezime] [nvarchar](255) NOT NULL,
	[datum_rođenja] [date] NOT NULL,
	[spol] [char](1) NOT NULL,
	[profilna_slika] [nvarchar](255) NOT NULL,
	[tip_ugovora] [nvarchar](255) NOT NULL,
	[pozicija] [nvarchar](255) NOT NULL,
	[odjel] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NULL,
	[role] [nvarchar](255) NOT NULL,
	[vrijeme_izrada_racuna] [datetime] NOT NULL,
 CONSTRAINT [PK__user_inf__3213E83FC185FEF8] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__user_inf__AB6E6164E3AD7D39] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[evidentirano_vrijeme] ADD  CONSTRAINT [DF__evidentir__sati___5AEE82B9]  DEFAULT (NULL) FOR [sati_zastoja_od]
GO
ALTER TABLE [dbo].[evidentirano_vrijeme] ADD  CONSTRAINT [DF__evidentir__sati___5BE2A6F2]  DEFAULT (NULL) FOR [sati_zastoja_do]
GO
ALTER TABLE [dbo].[radna_smjena_evidencija_radnika] ADD  CONSTRAINT [DF__radna_smj__sati___4316F928]  DEFAULT ((0)) FOR [sati_zastoja]
GO
ALTER TABLE [dbo].[radna_smjena_evidencija_radnika] ADD  CONSTRAINT [DF__radna_smj__evide__44FF419A]  DEFAULT ('U tijeku') FOR [evidentirano]
GO
ALTER TABLE [dbo].[radna_smjene] ADD  CONSTRAINT [DF__radna_smj__poseb__3C69FB99]  DEFAULT ((0)) FOR [posebni_dan]
GO
ALTER TABLE [dbo].[radnik_placa] ADD  CONSTRAINT [DF__radnik_pl__je_pl__49C3F6B7]  DEFAULT ((0)) FOR [je_placen]
GO
ALTER TABLE [dbo].[evidentirano_vrijeme]  WITH CHECK ADD  CONSTRAINT [FK__evidentir__evide__5DCAEF64] FOREIGN KEY([evidentiran_mjesec_id])
REFERENCES [dbo].[evidentiran_mjesec] ([id])
GO
ALTER TABLE [dbo].[evidentirano_vrijeme] CHECK CONSTRAINT [FK__evidentir__evide__5DCAEF64]
GO
ALTER TABLE [dbo].[radna_smjena_dani]  WITH CHECK ADD  CONSTRAINT [FK__radna_smj__id_ra__4BAC3F29] FOREIGN KEY([id_radna_smjena])
REFERENCES [dbo].[radna_smjene] ([id])
GO
ALTER TABLE [dbo].[radna_smjena_dani] CHECK CONSTRAINT [FK__radna_smj__id_ra__4BAC3F29]
GO
ALTER TABLE [dbo].[radna_smjena_dani]  WITH CHECK ADD  CONSTRAINT [FK__radna_smj__id_ra__5EBF139D] FOREIGN KEY([id_radna_smjena])
REFERENCES [dbo].[radna_smjene] ([id])
GO
ALTER TABLE [dbo].[radna_smjena_dani] CHECK CONSTRAINT [FK__radna_smj__id_ra__5EBF139D]
GO
ALTER TABLE [dbo].[radna_smjena_evidencija_radnika]  WITH CHECK ADD  CONSTRAINT [FK__radna_smj__id_ra__4F7CD00D] FOREIGN KEY([id_radna_smjena_radnici])
REFERENCES [dbo].[radna_smjena_radnici] ([id])
GO
ALTER TABLE [dbo].[radna_smjena_evidencija_radnika] CHECK CONSTRAINT [FK__radna_smj__id_ra__4F7CD00D]
GO
ALTER TABLE [dbo].[radna_smjena_evidencija_radnika]  WITH CHECK ADD  CONSTRAINT [FK__radna_smj__id_ra__628FA481] FOREIGN KEY([id_radna_smjena_radnici])
REFERENCES [dbo].[radna_smjena_radnici] ([id])
GO
ALTER TABLE [dbo].[radna_smjena_evidencija_radnika] CHECK CONSTRAINT [FK__radna_smj__id_ra__628FA481]
GO
ALTER TABLE [dbo].[radna_smjena_radnici]  WITH CHECK ADD  CONSTRAINT [FK__radna_smj__id_ra__4CA06362] FOREIGN KEY([id_radna_smjena_dani])
REFERENCES [dbo].[radna_smjena_dani] ([id])
GO
ALTER TABLE [dbo].[radna_smjena_radnici] CHECK CONSTRAINT [FK__radna_smj__id_ra__4CA06362]
GO
ALTER TABLE [dbo].[radna_smjena_radnici]  WITH CHECK ADD  CONSTRAINT [FK__radna_smj__id_ra__5FB337D6] FOREIGN KEY([id_radna_smjena_dani])
REFERENCES [dbo].[radna_smjena_dani] ([id])
GO
ALTER TABLE [dbo].[radna_smjena_radnici] CHECK CONSTRAINT [FK__radna_smj__id_ra__5FB337D6]
GO
ALTER TABLE [dbo].[radna_smjena_radnici]  WITH CHECK ADD  CONSTRAINT [FK__radna_smj__id_us__5070F446] FOREIGN KEY([id_user_information])
REFERENCES [dbo].[user_information] ([id])
GO
ALTER TABLE [dbo].[radna_smjena_radnici] CHECK CONSTRAINT [FK__radna_smj__id_us__5070F446]
GO
ALTER TABLE [dbo].[radna_smjena_radnici]  WITH CHECK ADD  CONSTRAINT [FK__radna_smj__id_us__6383C8BA] FOREIGN KEY([id_user_information])
REFERENCES [dbo].[user_information] ([id])
GO
ALTER TABLE [dbo].[radna_smjena_radnici] CHECK CONSTRAINT [FK__radna_smj__id_us__6383C8BA]
GO
ALTER TABLE [dbo].[radnik_placa]  WITH CHECK ADD  CONSTRAINT [FK__radnik_pl__id_ev__4D94879B] FOREIGN KEY([id_evidentiranog_mjeseca])
REFERENCES [dbo].[evidentiran_mjesec] ([id])
GO
ALTER TABLE [dbo].[radnik_placa] CHECK CONSTRAINT [FK__radnik_pl__id_ev__4D94879B]
GO
ALTER TABLE [dbo].[radnik_placa]  WITH CHECK ADD  CONSTRAINT [FK__radnik_pl__id_ev__60A75C0F] FOREIGN KEY([id_evidentiranog_mjeseca])
REFERENCES [dbo].[evidentiran_mjesec] ([id])
GO
ALTER TABLE [dbo].[radnik_placa] CHECK CONSTRAINT [FK__radnik_pl__id_ev__60A75C0F]
GO
ALTER TABLE [dbo].[radnik_placa]  WITH CHECK ADD  CONSTRAINT [FK__radnik_pl__id_ra__4E88ABD4] FOREIGN KEY([id_radnik])
REFERENCES [dbo].[user_information] ([id])
GO
ALTER TABLE [dbo].[radnik_placa] CHECK CONSTRAINT [FK__radnik_pl__id_ra__4E88ABD4]
GO
ALTER TABLE [dbo].[radnik_placa]  WITH CHECK ADD  CONSTRAINT [FK__radnik_pl__id_ra__619B8048] FOREIGN KEY([id_radnik])
REFERENCES [dbo].[user_information] ([id])
GO
ALTER TABLE [dbo].[radnik_placa] CHECK CONSTRAINT [FK__radnik_pl__id_ra__619B8048]
GO
ALTER TABLE [dbo].[evidentirano_vrijeme]  WITH CHECK ADD  CONSTRAINT [CK__evidentira__opis__5CD6CB2B] CHECK  (([opis]='Danju prekovremeni rad' OR [opis]='Danju rad neradnim danom' OR [opis]='Danju redovan rad' OR [opis]='Nocni prekovremeni rad' OR [opis]='Nocni rad neradnim_danom' OR [opis]='Nocni redovan rad' OR [opis]='Sati iskljucenja s rada' OR [opis]='Sati provedeni u strajku' OR [opis]='Izostanak s posla bez odobrenja' OR [opis]='Izostanak na zahtjev radnika' OR [opis]='Sati neplacenog dopusta' OR [opis]='Sati placenog dopusta' OR [opis]='Ostalo' OR [opis]='Mirovanje radnog odnosa' OR [opis]='Roditeljski dopust' OR [opis]='Rodilji dopust' OR [opis]='Komplikacije u trudnoci' OR [opis]='Bolovanje' OR [opis]='Placeni neradni dani' OR [opis]='Godisnji odmor' OR [opis]='Tjedni odmor' OR [opis]='Dnevni odmor' OR [opis]='Sati pripravnosti' OR [opis]='Terenski rad'))
GO
ALTER TABLE [dbo].[evidentirano_vrijeme] CHECK CONSTRAINT [CK__evidentira__opis__5CD6CB2B]
GO
ALTER TABLE [dbo].[radna_smjena_evidencija_radnika]  WITH CHECK ADD  CONSTRAINT [CK__radna_smj__evide__440B1D61] CHECK  (([evidentirano]='U tijeku' OR [evidentirano]='Neodobreno' OR [evidentirano]='Evidentirano'))
GO
ALTER TABLE [dbo].[radna_smjena_evidencija_radnika] CHECK CONSTRAINT [CK__radna_smj__evide__440B1D61]
GO
ALTER TABLE [dbo].[user_information]  WITH CHECK ADD  CONSTRAINT [CK__user_info__tip_u__38996AB5] CHECK  (([tip_ugovora]='Studentski ugovor' OR [tip_ugovora]='Ugovor o volontiranju' OR [tip_ugovora]='Ugovor o radu pripadnika' OR [tip_ugovora]='Ugovor o djelu' OR [tip_ugovora]='Probni rad' OR [tip_ugovora]='Ugovor o radu'))
GO
ALTER TABLE [dbo].[user_information] CHECK CONSTRAINT [CK__user_info__tip_u__38996AB5]
GO
ALTER TABLE [dbo].[user_information]  WITH CHECK ADD  CONSTRAINT [CK__user_infor__role__398D8EEE] CHECK  (([role]='Poslodavac' OR [role]='Knjigovoda' OR [role]='Korisnik' OR [role]='Administrator'))
GO
ALTER TABLE [dbo].[user_information] CHECK CONSTRAINT [CK__user_infor__role__398D8EEE]
GO
USE [master]
GO
ALTER DATABASE [E-Evidencija] SET  READ_WRITE 
GO
