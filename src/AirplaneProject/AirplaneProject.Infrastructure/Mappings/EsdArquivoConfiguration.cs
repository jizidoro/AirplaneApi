using AirplaneProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirplaneProject.Infrastructure.Mappings
{
    public class EsdArquivoConfiguration : IEntityTypeConfiguration<EsdArquivo>
    {
        public void Configure(EntityTypeBuilder<EsdArquivo> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Esd).WithMany(c => c.Arquivos).HasForeignKey(c => c.EsdId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.Property(c => c.NomeArquivo);
            builder.Property(c => c.Url).IsRequired();

            builder.HasIndex(c => c.Url).HasName("IX_EsdArquivos_Url");
        }
    }
}