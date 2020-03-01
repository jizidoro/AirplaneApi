SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER VIEW [dbo].[vwAlmoxarifado] as
select Almoxarifado.Id as Id
	  ,Almoxarifado.Codigo as AlmoxarifadoCodigo
	  ,Almoxarifado.Nome as AlmoxarifadoNome
	  ,Unidade.Id as UnidadeId
	  ,Unidade.Codigo as UnidadeCodigo
	  ,Unidade.Nome as UnidadeNome
	  ,Ativo.Id as AtivoId
	  ,Ativo.Codigo as AtivoCodigo
	  ,Ativo.Nome as AtivoNome
	  ,Uep.Id as UepId
	  ,Uep.Codigo as UepCodigo
	  ,Uep.Nome as UepNome
	  ,Almoxarifado.Codigo + ' ' + Unidade.Codigo + ' ' + Ativo.Codigo + ' ' + Uep.Codigo as DescricaoCodigo
FROM Almoxarifados as Almoxarifado
  INNER JOIN UepAlmoxarifados as UepAlmoxarifado ON UepAlmoxarifado.AlmoxarifadoId = Almoxarifado.Id
  INNER JOIN Ueps as Uep ON Uep.Id = UepAlmoxarifado.UepId
  INNER JOIN Ativos as Ativo ON Ativo.Id = Uep.AtivoId
  INNER JOIN UnidadesOperativas as Unidade ON Unidade.Id = Ativo.UnidadeOperativaId
Go

CREATE OR ALTER VIEW [dbo].[vwMaterialEstocado] as
SELECT MaterialEstocado.Id
	  ,MaterialEstocado.Codigo as MaterialEstocadoCodigo
	  ,MaterialEstocado.Nome as MaterialEstocadoNome
	  ,ClasseMaterial.Id as ClasseMaterialId
	  ,ClasseMaterial.Codigo as ClasseMaterialCodigo
	  ,ClasseMaterial.Nome as ClasseMaterialNome
	  ,CategoriaMaterial.Id as CategoriaMaterialId
	  ,CategoriaMaterial.Codigo as CategoriaMaterialCodigo
	  ,CategoriaMaterial.Nome as CategoriaMaterialNome
	  ,Fabricante.Id as FabricanteId
	  ,Fabricante.Codigo as FabricanteCodigo
	  ,Fabricante.Nome as FabricanteNome
	  ,MaterialFornecido.Id as MaterialFornecidoId
	  ,MaterialFornecido.Codigo as MaterialFornecidoCodigo
	  ,MaterialFornecido.Nome as MaterialFornecidoNome
	  ,MaterialFornecido.PartNumber as MaterialFornecidoPartNumber
	  ,Mrp.Id as MrpId
	  ,Mrp.Codigo as MrpCodigo
	  ,Mrp.Nome as MrpNome
	  ,Almoxarifado.Id as AlmoxarifadoId
	  ,Almoxarifado.Codigo as AlmoxarifadoCodigo
	  ,Almoxarifado.Nome as AlmoxarifadoNome
      ,MaterialEstocado.Descricao
	  ,MaterialEstocado.Codigo + ' ' + Almoxarifado.Codigo + ' ' + ClasseMaterial.Codigo + ' ' + CategoriaMaterial.Codigo + ' ' + Fabricante.Codigo +  ' ' + Mrp.Codigo + ' ' + MaterialFornecido.Codigo + ' ' + MaterialFornecido.PartNumber 
	  + (
	  CASE WHEN MaterialEstocado.Descricao is null 
	  THEN ' ' ELSE dbo.RemoveDiacritics(MaterialEstocado.Descricao)END
	  ) 
	  as DescricaoCodigo
  FROM MaterialEstocados as MaterialEstocado
  INNER JOIN Mrps as Mrp ON Mrp.Id = MaterialEstocado.MrpId
  INNER JOIN MaterialFornecidos as MaterialFornecido ON MaterialFornecido.Id = MaterialEstocado.MaterialFornecidoId
  INNER JOIN ClasseMateriais as ClasseMaterial ON ClasseMaterial.Id = MaterialFornecido.ClasseMaterialId
  INNER JOIN CategoriaMateriais as CategoriaMaterial ON CategoriaMaterial.Id = ClasseMaterial.CategoriaMaterialId
  INNER JOIN Fabricantes as Fabricante ON Fabricante.Id = MaterialFornecido.FabricanteId
  INNER JOIN Almoxarifados as Almoxarifado ON Almoxarifado.Id = MaterialEstocado.AlmoxarifadoId
GO

CREATE OR ALTER VIEW [dbo].[vwSobressalente] as
SELECT DISTINCT MaterialEstocado.Id 
	,SUBSTRING(
    (
        SELECT DISTINCT ', '+Almoxarifado.UnidadeNome  AS [text()]
        FROM dbo.vwAlmoxarifado  Almoxarifado
        WHERE Almoxarifado.Id = MaterialEstocado.AlmoxarifadoId
        FOR XML PATH ('')
    ), 2, 1000) [UnidadeNome]
	,SUBSTRING(
    (
        SELECT DISTINCT ', '+Almoxarifado.AtivoNome  AS [text()]
        FROM dbo.vwAlmoxarifado  Almoxarifado
        WHERE Almoxarifado.Id = MaterialEstocado.AlmoxarifadoId
        FOR XML PATH ('')
    ), 2, 1000) [AtivoNome]
	,SUBSTRING(
    (
        SELECT DISTINCT ', '+Almoxarifado.UepNome  AS [text()]
        FROM dbo.vwAlmoxarifado Almoxarifado
        WHERE Almoxarifado.Id = MaterialEstocado.AlmoxarifadoId
        FOR XML PATH ('')
    ), 2, 1000) [UepNome]
	,MaterialEstocado.MaterialEstocadoCodigo
	,MaterialEstocado.MaterialEstocadoNome
	,MaterialEstocado.AlmoxarifadoId
	,MaterialEstocado.AlmoxarifadoCodigo
	,MaterialEstocado.AlmoxarifadoNome
	,MaterialEstocado.CategoriaMaterialId
	,MaterialEstocado.CategoriaMaterialCodigo
	,MaterialEstocado.CategoriaMaterialNome
	,MaterialEstocado.ClasseMaterialId
	,MaterialEstocado.ClasseMaterialCodigo
	,MaterialEstocado.ClasseMaterialNome
	,MaterialEstocado.MaterialFornecidoId
	,MaterialEstocado.MaterialFornecidoCodigo
	,MaterialEstocado.MaterialFornecidoNome
	,MaterialEstocado.MaterialFornecidoPartNumber
	,MaterialEstocado.MrpId
	,MaterialEstocado.MrpCodigo
	,MaterialEstocado.MrpNome
	,MaterialEstocado.FabricanteId
	,MaterialEstocado.FabricanteCodigo
	,MaterialEstocado.FabricanteNome
	,MaterialEstocado.DescricaoCodigo
FROM dbo.vwMaterialEstocado MaterialEstocado
Go