﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OncoDiagnose.DataAccess;

namespace OncoDiagnose.DataAccess.Migrations
{
    [DbContext(typeof(OncoDbContext))]
    partial class OncoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Aliase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aliases");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Alteration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlterationInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConsequenceId")
                        .HasColumnType("int");

                    b.Property<int?>("GeneId")
                        .HasColumnType("int");

                    b.Property<int?>("MutationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProteinEnd")
                        .HasColumnType("int");

                    b.Property<int>("ProteinStart")
                        .HasColumnType("int");

                    b.Property<string>("RefResidues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VariantResidues")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConsequenceId");

                    b.HasIndex("GeneId");

                    b.HasIndex("MutationId");

                    b.ToTable("Alterations");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abstract")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Authors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElocationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Issue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Journal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pmid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PubDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Volume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("OncoDiagnose.Models.CancerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("MainType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tissue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TumorForm")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CancerTypes");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Consequence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGenerallyTruncating")
                        .HasColumnType("bit");

                    b.Property<string>("Term")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Consequences");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DrugName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NcitCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("OncoDiagnose.Models.DrugSynonym", b =>
                {
                    b.Property<int?>("DrugId")
                        .HasColumnType("int");

                    b.Property<int?>("SynonymId")
                        .HasColumnType("int");

                    b.HasKey("DrugId", "SynonymId");

                    b.HasIndex("SynonymId");

                    b.ToTable("DrugSynonyms");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Gene", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grch37Isoform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grch37RefSeq")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grch38Isoform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grch38RefSeq")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HugoSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OncoGene")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tsg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genes");
                });

            modelBuilder.Entity("OncoDiagnose.Models.GeneAliase", b =>
                {
                    b.Property<int?>("AliaseId")
                        .HasColumnType("int");

                    b.Property<int?>("GeneId")
                        .HasColumnType("int");

                    b.HasKey("AliaseId", "GeneId");

                    b.HasIndex("GeneId");

                    b.ToTable("GeneAliases");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Mutation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalInfor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int?>("CancerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EvidenceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KnownEffect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastEdit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastReview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LevelOfEvidence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LiquidPropagationLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolidPropagationLevel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CancerTypeId");

                    b.ToTable("Mutations");
                });

            modelBuilder.Entity("OncoDiagnose.Models.MutationArticle", b =>
                {
                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int?>("MutationId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "MutationId");

                    b.HasIndex("MutationId");

                    b.ToTable("MutationArticles");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Synonym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SynonymInformation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Synonyms");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Technician.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Agent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BarCode")
                        .HasColumnType("int");

                    b.Property<string>("BirthPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Explain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsectDoctor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InspectDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InspectDepartment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InspectHospital")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KeepMethod")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherDisease")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReceiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiveState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sales")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SampleType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransportMethod")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Technician.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Frequence")
                        .HasColumnType("float");

                    b.Property<string>("GeneName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("Variant")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Technician.Run", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FinishDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISPLoading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISPLoadingPic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeySignal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LengthPic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LowQuality")
                        .HasColumnType("int");

                    b.Property<double>("MeanLength")
                        .HasColumnType("float");

                    b.Property<int>("MedianLength")
                        .HasColumnType("int");

                    b.Property<int>("ModeLength")
                        .HasColumnType("int");

                    b.Property<string>("PolyClonal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QualityPic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TotalBase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalRead")
                        .HasColumnType("int");

                    b.Property<double>("UsableRead")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Runs");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Technician.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("RunId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TestName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("RunId")
                        .IsUnique();

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MutationId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MutationId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("OncoDiagnose.Models.TreatmentDrugs", b =>
                {
                    b.Property<int?>("DrugId")
                        .HasColumnType("int");

                    b.Property<int?>("TreatmentId")
                        .HasColumnType("int");

                    b.HasKey("DrugId", "TreatmentId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("TreatmentDrugs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OncoDiagnose.Models.Alteration", b =>
                {
                    b.HasOne("OncoDiagnose.Models.Consequence", "Consequence")
                        .WithMany("Alterations")
                        .HasForeignKey("ConsequenceId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("OncoDiagnose.Models.Gene", "Gene")
                        .WithMany("Alterations")
                        .HasForeignKey("GeneId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("OncoDiagnose.Models.Mutation", "Mutation")
                        .WithMany("Alterations")
                        .HasForeignKey("MutationId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("Consequence");

                    b.Navigation("Gene");

                    b.Navigation("Mutation");
                });

            modelBuilder.Entity("OncoDiagnose.Models.DrugSynonym", b =>
                {
                    b.HasOne("OncoDiagnose.Models.Drug", "Drug")
                        .WithMany("DrugSynonyms")
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OncoDiagnose.Models.Synonym", "Synonym")
                        .WithMany("DrugSynonyms")
                        .HasForeignKey("SynonymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drug");

                    b.Navigation("Synonym");
                });

            modelBuilder.Entity("OncoDiagnose.Models.GeneAliase", b =>
                {
                    b.HasOne("OncoDiagnose.Models.Aliase", "Aliase")
                        .WithMany("GeneAliases")
                        .HasForeignKey("AliaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OncoDiagnose.Models.Gene", "Gene")
                        .WithMany("GeneAliases")
                        .HasForeignKey("GeneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aliase");

                    b.Navigation("Gene");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Mutation", b =>
                {
                    b.HasOne("OncoDiagnose.Models.Article", null)
                        .WithMany("Mutations")
                        .HasForeignKey("ArticleId");

                    b.HasOne("OncoDiagnose.Models.CancerType", "CancerType")
                        .WithMany("Mutations")
                        .HasForeignKey("CancerTypeId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("CancerType");
                });

            modelBuilder.Entity("OncoDiagnose.Models.MutationArticle", b =>
                {
                    b.HasOne("OncoDiagnose.Models.Article", "Article")
                        .WithMany("MutationArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OncoDiagnose.Models.Mutation", "Mutation")
                        .WithMany("MutationArticles")
                        .HasForeignKey("MutationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Mutation");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Technician.Result", b =>
                {
                    b.HasOne("OncoDiagnose.Models.Technician.Test", "Test")
                        .WithMany("Results")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Technician.Test", b =>
                {
                    b.HasOne("OncoDiagnose.Models.Technician.Patient", "Patient")
                        .WithMany("Tests")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("OncoDiagnose.Models.Technician.Run", "Run")
                        .WithOne("Test")
                        .HasForeignKey("OncoDiagnose.Models.Technician.Test", "RunId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Run");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Treatment", b =>
                {
                    b.HasOne("OncoDiagnose.Models.Mutation", "Mutation")
                        .WithMany("Treatments")
                        .HasForeignKey("MutationId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("Mutation");
                });

            modelBuilder.Entity("OncoDiagnose.Models.TreatmentDrugs", b =>
                {
                    b.HasOne("OncoDiagnose.Models.Drug", "Drug")
                        .WithMany("TreatmentDrugs")
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OncoDiagnose.Models.Treatment", "Treatment")
                        .WithMany("TreatmentDrugs")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drug");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Aliase", b =>
                {
                    b.Navigation("GeneAliases");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Article", b =>
                {
                    b.Navigation("MutationArticles");

                    b.Navigation("Mutations");
                });

            modelBuilder.Entity("OncoDiagnose.Models.CancerType", b =>
                {
                    b.Navigation("Mutations");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Consequence", b =>
                {
                    b.Navigation("Alterations");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Drug", b =>
                {
                    b.Navigation("DrugSynonyms");

                    b.Navigation("TreatmentDrugs");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Gene", b =>
                {
                    b.Navigation("Alterations");

                    b.Navigation("GeneAliases");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Mutation", b =>
                {
                    b.Navigation("Alterations");

                    b.Navigation("MutationArticles");

                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Synonym", b =>
                {
                    b.Navigation("DrugSynonyms");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Technician.Patient", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Technician.Run", b =>
                {
                    b.Navigation("Test");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Technician.Test", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("OncoDiagnose.Models.Treatment", b =>
                {
                    b.Navigation("TreatmentDrugs");
                });
#pragma warning restore 612, 618
        }
    }
}
