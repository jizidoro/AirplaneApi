namespace AirplaneProject.Domain.Queries
{
    public class MaterialEstocadoExportacaoQuery
    {
        public string CentroMrp { get; set; }
        public string AreaMrp { get; set; }
        public string NmMaterial { get; set; }
        public double Estoque { get; set; }
        public string Mrp { get; set; }
        public double QtdMinima { get; set; }
        public double QtdMaxima { get; set; }
    }
}
