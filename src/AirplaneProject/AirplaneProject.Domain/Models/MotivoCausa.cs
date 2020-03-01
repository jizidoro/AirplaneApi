using AirplaneProject.Domain.Bases;

namespace AirplaneProject.Domain.Models
{
    public class MotivoCausa : AssociacaoEntity
	{
		public int MotivoId { get; set; }
		public Motivo Motivo { get; set; }
		public int CausaId { get; set; }
		public Causa Causa { get; set; }
		
		public override string Value
		{
			get
			{
				if (this.Causa != null)
				{
					return this.Causa.Nome;
				}
				else if (this.Motivo != null)
				{
					return this.Motivo.Nome;
				}
				else
				{
					return this.ToString();
				}
			}
		}
		public override int ParentKey => this.MotivoId;
	}
}