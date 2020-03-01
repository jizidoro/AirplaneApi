SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[vwMaterialEstocado] as
SELECT MaterialEstocado.Id
	  ,SituacaoMaterial.Id as SituacaoMaterialId
	  ,SituacaoMaterial.Codigo as SituacaoMaterialCodigo
	  ,SituacaoMaterial.Nome as SituacaoMaterialNome
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
	  ,MaterialFornecido.NM as MaterialFornecidoNM
	  ,MaterialFornecido.PartNumber as MaterialFornecidoPartNumber
	  ,Mrp.Id as MrpId
	  ,Mrp.Codigo as MrpCodigo
	  ,Mrp.Nome as MrpNome
	  ,Almoxarifado.Id as AlmoxarifadoId
	  ,Almoxarifado.Codigo as AlmoxarifadoCodigo
	  ,Almoxarifado.Nome as AlmoxarifadoNome
	  ,Almoxarifado.Codigo + ' ' + ClasseMaterial.Codigo + ' ' + CategoriaMaterial.Codigo + ' ' + Fabricante.Codigo +  ' ' + Mrp.Codigo + ' ' + MaterialFornecido.Codigo + ' ' + MaterialFornecido.PartNumber as DescricaoCodigo
  FROM MaterialEstocados as MaterialEstocado
  INNER JOIN Mrps as Mrp ON Mrp.Id = MaterialEstocado.MrpId
  INNER JOIN SituacaoMateriais as SituacaoMaterial ON SituacaoMaterial.Id = MaterialEstocado.SituacaoMaterialId
  INNER JOIN MaterialFornecidos as MaterialFornecido ON MaterialFornecido.Id = MaterialEstocado.MaterialFornecidoId
  INNER JOIN ClasseMateriais as ClasseMaterial ON ClasseMaterial.Id = MaterialFornecido.ClasseMaterialId
  INNER JOIN CategoriaMateriais as CategoriaMaterial ON CategoriaMaterial.Id = ClasseMaterial.CategoriaMaterialId
  INNER JOIN Fabricantes as Fabricante ON Fabricante.Id = MaterialFornecido.FabricanteId
  INNER JOIN Almoxarifados as Almoxarifado ON Almoxarifado.Id = MaterialEstocado.AlmoxarifadoId
GO

ALTER VIEW [dbo].[vwSobressalente] as
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
	,MaterialEstocado.AlmoxarifadoId
	,MaterialEstocado.AlmoxarifadoCodigo
	,MaterialEstocado.AlmoxarifadoNome
	,MaterialEstocado.SituacaoMaterialId
	,MaterialEstocado.SituacaoMaterialCodigo
	,MaterialEstocado.SituacaoMaterialNome
	,MaterialEstocado.CategoriaMaterialId
	,MaterialEstocado.CategoriaMaterialCodigo
	,MaterialEstocado.CategoriaMaterialNome
	,MaterialEstocado.ClasseMaterialId
	,MaterialEstocado.ClasseMaterialCodigo
	,MaterialEstocado.ClasseMaterialNome
	,MaterialEstocado.MaterialFornecidoId
	,MaterialEstocado.MaterialFornecidoCodigo
	,MaterialEstocado.MaterialFornecidoNM
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