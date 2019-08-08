﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.DbRepository;
using IslbTransfers.CustomAttributes;
using IslbTransfers.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.Models;
using Service.Services;

namespace IslbTransfers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            });
            IMapper mapper = new Mapper(mapConfig);
            services.AddSingleton(mapper);

            services.AddCors();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("OAuthSettings");
            services.Configure<OAuthSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<OAuthSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<SessionAuthorizeAttribute>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDbRepository<User>, DbRepository<User>>();
            services.AddScoped<IDbRepository<UserSession>, DbRepository<UserSession>>();
            services.AddScoped<IDbRepository<UserIdentityKyc>, DbRepository<UserIdentityKyc>>();
            services.AddScoped<IDbRepository<UserExternalLogin>, DbRepository<UserExternalLogin>>();
            services.AddScoped<IDbRepository<UserWallet>, DbRepository<UserWallet>>();

            services.AddScoped<ITransactionService, TransactionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/#/error");
            }

            app.UseAuthentication();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "UserUploads")),
                RequestPath = "/uploads"
            });
            app.UseMvc();
            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
        }
    }
}
