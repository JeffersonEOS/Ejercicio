using auriga2.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace auriga2.infraestructure.data.configs;
public class EmailTemplateConfig : IEntityTypeConfiguration<EmailTemplateEntity>
{ 
    public void Configure(EntityTypeBuilder<EmailTemplateEntity> builder)
    { 
        builder.ToTable("emails_templates");
    }}