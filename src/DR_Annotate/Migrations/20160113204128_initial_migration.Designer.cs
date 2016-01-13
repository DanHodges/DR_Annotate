using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DR_Annotate.Models;

namespace DR_Annotate.Migrations
{
    [DbContext(typeof(DR_AnnotateContext))]
    [Migration("20160113204128_initial_migration")]
    partial class initial_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DR_Annotate.Models.Annotation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("bookTitle");

                    b.Property<string>("category");

                    b.Property<int>("chapterNumber");

                    b.Property<string>("content");

                    b.Property<int>("end");

                    b.Property<int>("start");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DR_Annotate.Models.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookTitle");

                    b.Property<int>("ChapterNumber");

                    b.Property<string>("EntireChapterString");

                    b.Property<string>("title");

                    b.HasKey("Id");
                });
        }
    }
}
