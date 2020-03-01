SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP FULLTEXT INDEX ON [dbo].[esds]
GO

drop VIEW [dbo].[vwEsd]
GO

drop FUNCTION [dbo].[RemoveDiacritics]
GO

drop view [dbo].[vwNivelUep]
GO

drop view [dbo].[vwEquipamentoIniciadorUep]
GO

drop view [dbo].[vwIniciadorUep]
GO

drop view [dbo].[vwAgenteOrigem]
GO

drop view [dbo].[vwAgenteEspecifico]
GO

drop view [dbo].[vwAgenteGenerico]
GO