﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

//Kullanıcı yetkilendirmeleri
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog") { Scopes = { "CatalogFullPermission","CatalogReadPermission" } },
            new ApiResource("ResourceDiscount") { Scopes = {"DicountFullPermission" } },
            new ApiResource("ResourceOrder") { Scopes = {"OrderFullPermission" } },
            new ApiResource("ResourceCargo") { Scopes = {"CargoFullPermission" } },
            new ApiResource("ResourceBasket") { Scopes = {"BasketFullPermission" } },
            new ApiResource("ResourceComment") { Scopes = {"CommentFullPermission" } },
            new ApiResource("ResourcePayment") { Scopes = {"PaymentFullPermission" } },
            new ApiResource("ResourceImages") { Scopes = {"ImagesFullPermission" } },
            new ApiResource("ResourceOcelot") { Scopes = {"OcelotFullPermission" } },
            new ApiResource("ResourceMessage") { Scopes = {"MessageFullPermission" } },

            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };


        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission", "Reading authority for catalog operations"),
            new ApiScope("DicountFullPermission", "Full authority for discoıunt operations"),
            new ApiScope("OrderFullPermission", "Full authority for order operations"),
            new ApiScope("CargoFullPermission", "Full authority for cargo operations"),
            new ApiScope("BasketFullPermission", "Full authority for basket operations"),
            new ApiScope("CommentFullPermission", "Full authority for comment operations"),
            new ApiScope("PaymentFullPermission", "Full authority for payment operations"),
            new ApiScope("ImagesFullPermission", "Full authority for images operations"),
            new ApiScope("OcelotFullPermission", "Full authority for ocelot operations"),
            new ApiScope("MessageFullPermission", "Full authority for message operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="MultiShopVisitorID",
                ClientName="MultiShop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={"CatalogReadPermission","CatalogFullPermission","OcelotFullPermission","CommentFullPermission","ImagesFullPermission"}
            },
            //Manager
            new Client
            {
                ClientId="MultiShopManagerID",
                ClientName="MultiShop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={"CatalogReadPermission","CatalogFullPermission","BasketFullPermission", "OcelotFullPermission","OrderFullPermission", "CommentFullPermission", "CargoFullPermission","ImagesFullPermission","MessageFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email
                }
            },
           //Admin
            new Client
            {
                ClientId="MultiShopAdminID",
                ClientName="MultiShop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={"CatalogReadPermission","CatalogFullPermission","DiscountFullPermission","OrderFullPermission","CargoFullPermission","BasketFullPermission","OcelotFullPermission","CommentFullPermission","PaymentFullPermission","ImagesFullPermission","OrderFullPermission","MessageFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email
                },
                AccessTokenLifetime=600
            }
        };
    };

}