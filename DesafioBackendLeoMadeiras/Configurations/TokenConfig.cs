﻿using DesafioBackendLeoMadeiras.Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace DesafioBackendLeoMadeiras.API.Configurations
{
    public static class TokenConfig
    {
        public static void AddTokenConfiguration(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(ConfiguracaoToken.Chave);
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
                         ClockSkew = TimeSpan.Zero
                     };
                 });
        }
    }
}
