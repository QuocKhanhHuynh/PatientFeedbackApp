﻿// <auto-generated />
using System;
using FeedbackApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FeedbackApp.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240524141651_initalization")]
    partial class initalization
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FeedbackApp.Data.Entities.Client", b =>
                {
                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("so_dien_thoai");

                    b.Property<short>("Age")
                        .HasColumnType("smallint")
                        .HasColumnName("tuoi");

                    b.Property<short?>("DayNumber")
                        .HasColumnType("smallint")
                        .HasColumnName("so_ngay_dieu_tri");

                    b.Property<short>("Distance")
                        .HasColumnType("smallint")
                        .HasColumnName("khoang_cach");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("ho_ten");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("gioi_tinh");

                    b.Property<bool?>("IsInsurance")
                        .HasColumnType("boolean")
                        .HasColumnName("su_dung_bhyt");

                    b.HasKey("PhoneNumber");

                    b.ToTable("benh_nhan");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.CloseFeedbackDetail", b =>
                {
                    b.Property<long>("FeedbackId")
                        .HasColumnType("bigint")
                        .HasColumnName("ma_phan_hoi");

                    b.Property<short>("CloseQuestionId")
                        .HasColumnType("smallint")
                        .HasColumnName("ma_cau_hoi_dong");

                    b.Property<short>("ScoreId")
                        .HasColumnType("smallint")
                        .HasColumnName("ma_muc_do_diem");

                    b.HasKey("FeedbackId", "CloseQuestionId");

                    b.HasIndex("CloseQuestionId");

                    b.HasIndex("ScoreId");

                    b.ToTable("chi_tiet_khao_sat_dong");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.CloseFeedbackQuestion", b =>
                {
                    b.Property<string>("FeedbackTypeId")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("ma_loai_khao_sat");

                    b.Property<short>("CloseQuestionId")
                        .HasColumnType("smallint")
                        .HasColumnName("ma_cau_hoi_dong");

                    b.HasKey("FeedbackTypeId", "CloseQuestionId");

                    b.HasIndex("CloseQuestionId");

                    b.ToTable("cau_hoi_khao_sat_dong");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.CloseQuestion", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("ma_cau_hoi_dong");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<string>("CloseQuestionCategoryId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("ma_danh_muc_cau_hoi_dong");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ten_cau_hoi_dong");

                    b.Property<short>("OrdinalNumber")
                        .HasColumnType("smallint")
                        .HasColumnName("thu_tu");

                    b.Property<string>("ScoreTypeId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("ma_loai_muc_do_danh_gia");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("trang_thai");

                    b.HasKey("Id");

                    b.HasIndex("CloseQuestionCategoryId");

                    b.HasIndex("ScoreTypeId");

                    b.ToTable("cau_hoi_dong");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.CloseQuestionCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("ma_danh_muc_cau_hoi_dong");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ten_danh_muc_cau_hoi_dong");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("trang_thai");

                    b.HasKey("Id");

                    b.ToTable("danh_muc_cau_hoi_dong");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Employee", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("ten_dang_nhap");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("thu_dien_tu");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("ho_ten");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("mat_khau");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("so_dien_thoai");

                    b.HasKey("Username");

                    b.ToTable("nhan_vien");

                    b.HasData(
                        new
                        {
                            Username = "quockhanh",
                            Email = "khanhhuynh912@gmail.com",
                            Fullname = "Huỳnh Quốc Khánh",
                            Password = "376235639513033711459238240508416048",
                            PhoneNumber = "0334190027"
                        });
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Feedback", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ma_phan_hoi");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("thoi_gian_thuc_hien");

                    b.Property<short>("DayNumber")
                        .HasColumnType("smallint")
                        .HasColumnName("so_ngay_dieu_tri");

                    b.Property<string>("FeebackTypeId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("ma_loai_khao_sat");

                    b.Property<bool>("IsInsurance")
                        .HasColumnType("boolean")
                        .HasColumnName("su_dung_bhyt");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("so_dien_thoai");

                    b.HasKey("Id");

                    b.HasIndex("FeebackTypeId");

                    b.HasIndex("PhoneNumber");

                    b.ToTable("phan_hoi");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.FeedbackType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("ma_loai_khao_sat");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ten_loai_khao_sat");

                    b.HasKey("Id");

                    b.ToTable("loai_khao_sat");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Function", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("ma_hoat_dong");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("ten_hoat_dong");

                    b.HasKey("Id");

                    b.ToTable("hoat_dong");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Limit", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("ten_dang_nhap");

                    b.Property<short>("FunctionId")
                        .HasColumnType("smallint")
                        .HasColumnName("ma_hoat_dong");

                    b.HasKey("Username", "FunctionId");

                    b.HasIndex("FunctionId");

                    b.ToTable("quyen");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.OpenFeedbackDetail", b =>
                {
                    b.Property<long>("FeedbackId")
                        .HasColumnType("bigint")
                        .HasColumnName("ma_phan_hoi");

                    b.Property<short>("OpenQuestionId")
                        .HasColumnType("smallint")
                        .HasColumnName("ma_cau_hoi_mo");

                    b.Property<string>("Conttent")
                        .HasColumnType("text");

                    b.HasKey("FeedbackId", "OpenQuestionId");

                    b.HasIndex("OpenQuestionId");

                    b.ToTable("chi_tiet_khao_sat_mo");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.OpenFeedbackQuestion", b =>
                {
                    b.Property<string>("FeedbackTypeId")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("ma_loai_khao_sat");

                    b.Property<short>("OpenQuestionId")
                        .HasColumnType("smallint")
                        .HasColumnName("ma_cau_hoi_dong");

                    b.HasKey("FeedbackTypeId", "OpenQuestionId");

                    b.HasIndex("OpenQuestionId");

                    b.ToTable("cau_hoi_khao_sat_mo");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.OpenQuestion", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("ma_cau_hoi_mo");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ten_cau_hoi_mo");

                    b.Property<short>("OrdinalNumber")
                        .HasColumnType("smallint")
                        .HasColumnName("thu_tu");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("trang_thai");

                    b.HasKey("Id");

                    b.ToTable("cau_hoi_mo");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Score", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("ma_muc_do_diem");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("ten_muc_do_diem");

                    b.Property<short>("Number")
                        .HasColumnType("smallint")
                        .HasColumnName("muc_diem_so");

                    b.Property<string>("ScoreTypeId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("ma_loai_muc_do_danh_gia");

                    b.HasKey("Id");

                    b.HasIndex("ScoreTypeId");

                    b.ToTable("muc_do");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.ScoreType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("ma_loai_muc_do_danh_gia");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ten_loai_muc_do_danh_gia");

                    b.HasKey("Id");

                    b.ToTable("loai_muc_do_danh_gia");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.CloseFeedbackDetail", b =>
                {
                    b.HasOne("FeedbackApp.Data.Entities.CloseQuestion", "CloseQuestion")
                        .WithMany("CloseFeedbackDetails")
                        .HasForeignKey("CloseQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedbackApp.Data.Entities.Feedback", "Feedback")
                        .WithMany("CloseFeedbackDetails")
                        .HasForeignKey("FeedbackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedbackApp.Data.Entities.Score", "Score")
                        .WithMany("CloseFeedbackDetails")
                        .HasForeignKey("ScoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CloseQuestion");

                    b.Navigation("Feedback");

                    b.Navigation("Score");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.CloseFeedbackQuestion", b =>
                {
                    b.HasOne("FeedbackApp.Data.Entities.CloseQuestion", "CloseQuestion")
                        .WithMany("CloseFeedbackQuestions")
                        .HasForeignKey("CloseQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedbackApp.Data.Entities.FeedbackType", "FeedbackType")
                        .WithMany("CloseFeedbackQuestions")
                        .HasForeignKey("FeedbackTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CloseQuestion");

                    b.Navigation("FeedbackType");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.CloseQuestion", b =>
                {
                    b.HasOne("FeedbackApp.Data.Entities.CloseQuestionCategory", "CloseQuestionCategory")
                        .WithMany("CloseQuestions")
                        .HasForeignKey("CloseQuestionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedbackApp.Data.Entities.ScoreType", "ScoreType")
                        .WithMany("CloseQuestions")
                        .HasForeignKey("ScoreTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CloseQuestionCategory");

                    b.Navigation("ScoreType");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Feedback", b =>
                {
                    b.HasOne("FeedbackApp.Data.Entities.FeedbackType", "FeedbackType")
                        .WithMany("Feedbacks")
                        .HasForeignKey("FeebackTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedbackApp.Data.Entities.Client", "Client")
                        .WithMany("Feedbacks")
                        .HasForeignKey("PhoneNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("FeedbackType");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Limit", b =>
                {
                    b.HasOne("FeedbackApp.Data.Entities.Function", "Function")
                        .WithMany("Limits")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedbackApp.Data.Entities.Employee", "Employee")
                        .WithMany("Limits")
                        .HasForeignKey("Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Function");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.OpenFeedbackDetail", b =>
                {
                    b.HasOne("FeedbackApp.Data.Entities.Feedback", "Feedback")
                        .WithMany("OpenFeedbackDetail")
                        .HasForeignKey("FeedbackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedbackApp.Data.Entities.OpenQuestion", "OpenQuestion")
                        .WithMany("OpenFeedbackDetail")
                        .HasForeignKey("OpenQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feedback");

                    b.Navigation("OpenQuestion");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.OpenFeedbackQuestion", b =>
                {
                    b.HasOne("FeedbackApp.Data.Entities.FeedbackType", "FeedbackType")
                        .WithMany("OpenFeedbackQuestions")
                        .HasForeignKey("FeedbackTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FeedbackApp.Data.Entities.OpenQuestion", "OpenQuestion")
                        .WithMany("OpenFeedbackQuestions")
                        .HasForeignKey("OpenQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeedbackType");

                    b.Navigation("OpenQuestion");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Score", b =>
                {
                    b.HasOne("FeedbackApp.Data.Entities.ScoreType", "ScoreType")
                        .WithMany("Scores")
                        .HasForeignKey("ScoreTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScoreType");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Client", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.CloseQuestion", b =>
                {
                    b.Navigation("CloseFeedbackDetails");

                    b.Navigation("CloseFeedbackQuestions");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.CloseQuestionCategory", b =>
                {
                    b.Navigation("CloseQuestions");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Employee", b =>
                {
                    b.Navigation("Limits");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Feedback", b =>
                {
                    b.Navigation("CloseFeedbackDetails");

                    b.Navigation("OpenFeedbackDetail");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.FeedbackType", b =>
                {
                    b.Navigation("CloseFeedbackQuestions");

                    b.Navigation("Feedbacks");

                    b.Navigation("OpenFeedbackQuestions");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Function", b =>
                {
                    b.Navigation("Limits");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.OpenQuestion", b =>
                {
                    b.Navigation("OpenFeedbackDetail");

                    b.Navigation("OpenFeedbackQuestions");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.Score", b =>
                {
                    b.Navigation("CloseFeedbackDetails");
                });

            modelBuilder.Entity("FeedbackApp.Data.Entities.ScoreType", b =>
                {
                    b.Navigation("CloseQuestions");

                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
