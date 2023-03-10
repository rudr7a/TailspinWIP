// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tailspin.Surveys.Data.DataModels;

namespace Tailspin.Surveys.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.ContributorRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id", "SurveyId", "TenantId");

                    b.HasIndex("TenantId");

                    b.HasIndex("SurveyId", "TenantId");

                    b.ToTable("ContributorRequests");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<string>("PossibleAnswers")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id", "SurveyId", "TenantId");

                    b.HasIndex("TenantId");

                    b.HasIndex("SurveyId", "TenantId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Published")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id", "TenantId");

                    b.HasIndex("OwnerId", "TenantId");

                    b.HasIndex("TenantId", "OwnerId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.SurveyContributor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.HasKey("Id", "SurveyId", "TenantId");

                    b.HasIndex("TenantId");

                    b.HasIndex("SurveyId", "TenantId");

                    b.ToTable("SurveyContributors");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IssuerValue")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("ObjectId")
                        .HasColumnType("text");

                    b.HasKey("Id", "TenantId");

                    b.HasIndex("TenantId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.ContributorRequest", b =>
                {
                    b.HasOne("Tailspin.Surveys.Data.DataModels.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tailspin.Surveys.Data.DataModels.Survey", "Survey")
                        .WithMany("ContributerRequests")
                        .HasForeignKey("SurveyId", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.Question", b =>
                {
                    b.HasOne("Tailspin.Surveys.Data.DataModels.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tailspin.Surveys.Data.DataModels.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.Survey", b =>
                {
                    b.HasOne("Tailspin.Surveys.Data.DataModels.Tenant", null)
                        .WithMany("Surveys")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tailspin.Surveys.Data.DataModels.User", "Owner")
                        .WithMany("OwnedSurveys")
                        .HasForeignKey("OwnerId", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tailspin.Surveys.Data.DataModels.User", "Tenant")
                        .WithMany("Surveys")
                        .HasForeignKey("TenantId", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.SurveyContributor", b =>
                {
                    b.HasOne("Tailspin.Surveys.Data.DataModels.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tailspin.Surveys.Data.DataModels.Survey", "Survey")
                        .WithMany("Contributors")
                        .HasForeignKey("SurveyId", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.User", b =>
                {
                    b.HasOne("Tailspin.Surveys.Data.DataModels.Tenant", "Tenant")
                        .WithMany("Users")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.Survey", b =>
                {
                    b.Navigation("ContributerRequests");

                    b.Navigation("Contributors");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.Tenant", b =>
                {
                    b.Navigation("Surveys");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Tailspin.Surveys.Data.DataModels.User", b =>
                {
                    b.Navigation("OwnedSurveys");

                    b.Navigation("Surveys");
                });
#pragma warning restore 612, 618
        }
    }
}
