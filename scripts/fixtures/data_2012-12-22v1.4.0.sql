USE [shopnet]
GO
/****** Object:  Table [dbo].[ITEM]    Script Date: 12/22/2012 19:21:39 ******/
/****** Object:  Table [dbo].[PROVIDER]    Script Date: 12/22/2012 19:21:39 ******/
SET IDENTITY_INSERT [dbo].[PROVIDER] ON
INSERT [dbo].[PROVIDER] ([ID_PROVIDER], [NAME_PROVIDER], [DESC_PROVIDER], [CREATION_PROVIDER], [ADDRESS_PROVIDER], [PHONE_PROVIDER]) VALUES (1, N'Provider 1', NULL, CAST(0x0000A12F013BCDB6 AS DateTime), NULL, NULL)
INSERT [dbo].[PROVIDER] ([ID_PROVIDER], [NAME_PROVIDER], [DESC_PROVIDER], [CREATION_PROVIDER], [ADDRESS_PROVIDER], [PHONE_PROVIDER]) VALUES (2, N'Provider 2', NULL, CAST(0x0000A12F013BD671 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[PROVIDER] OFF
/****** Object:  Table [dbo].[PRODUCT]    Script Date: 12/22/2012 19:21:39 ******/
SET IDENTITY_INSERT [dbo].[PRODUCT] ON
INSERT [dbo].[PRODUCT] ([ID_PRODUCT], [CODE_PRODUCT], [NAME_PRODUCT], [DESC_PRODUCT], [MINIMUM_PRODUCT], [CREATION_PRODUCT]) VALUES (1, N'COD - Product 1', N'Product 1', NULL, NULL, CAST(0x0000A12F013B8463 AS DateTime))
INSERT [dbo].[PRODUCT] ([ID_PRODUCT], [CODE_PRODUCT], [NAME_PRODUCT], [DESC_PRODUCT], [MINIMUM_PRODUCT], [CREATION_PRODUCT]) VALUES (2, N'COD - Product 2', N'Product 2', NULL, NULL, CAST(0x0000A12F013B96F0 AS DateTime))
SET IDENTITY_INSERT [dbo].[PRODUCT] OFF
/****** Object:  Table [dbo].[USER]    Script Date: 12/22/2012 19:21:39 ******/
SET IDENTITY_INSERT [dbo].[USER] ON
INSERT [dbo].[USER] ([ID_USER], [NAME_USER], [PASSWORD_USER], [EMAIL_USER], [CREATION_USER], [STATUS_USER]) VALUES (5, N'diego', N'078c007bd92ddec308ae2f5115c1775d', N'diego.loza.click@gmail.com', CAST(0x0000A12F0127D6DC AS DateTime), 1)
INSERT [dbo].[USER] ([ID_USER], [NAME_USER], [PASSWORD_USER], [EMAIL_USER], [CREATION_USER], [STATUS_USER]) VALUES (6, N'roger', N'd7403066713e9d99bcc97a8db69bfb67', N'rogerex@live.com', CAST(0x0000A12F013C70C0 AS DateTime), 1)
INSERT [dbo].[USER] ([ID_USER], [NAME_USER], [PASSWORD_USER], [EMAIL_USER], [CREATION_USER], [STATUS_USER]) VALUES (7, N'ronald', N'5af0a0feb2094f43bebb50c518c1ebfe', N'ronald.vinaya.click@gmail.com', CAST(0x0000A12F013E176B AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[USER] OFF
/****** Object:  Table [dbo].[TYPE_PAYMENT]    Script Date: 12/22/2012 19:21:39 ******/
SET IDENTITY_INSERT [dbo].[TYPE_PAYMENT] ON
INSERT [dbo].[TYPE_PAYMENT] ([ID_TYPE_PAYMENT], [NAME_TYPE_PAYMENT], [STATUS_TYPE_PAYMENT], [DESC_TYPE_PAYMENT], [AMOUNT_TYPE_PAYMENT], [TOTAL_SALE_MINIMUM]) VALUES (2, N'Type Payment 1', 1, NULL, NULL, NULL)
INSERT [dbo].[TYPE_PAYMENT] ([ID_TYPE_PAYMENT], [NAME_TYPE_PAYMENT], [STATUS_TYPE_PAYMENT], [DESC_TYPE_PAYMENT], [AMOUNT_TYPE_PAYMENT], [TOTAL_SALE_MINIMUM]) VALUES (3, N'Type Payment 2', 1, NULL, NULL, NULL)
INSERT [dbo].[TYPE_PAYMENT] ([ID_TYPE_PAYMENT], [NAME_TYPE_PAYMENT], [STATUS_TYPE_PAYMENT], [DESC_TYPE_PAYMENT], [AMOUNT_TYPE_PAYMENT], [TOTAL_SALE_MINIMUM]) VALUES (4, N'Type Payment 3', 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TYPE_PAYMENT] OFF
/****** Object:  Table [dbo].[ROLE]    Script Date: 12/22/2012 19:21:39 ******/
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 12/22/2012 19:21:39 ******/
SET IDENTITY_INSERT [dbo].[CUSTOMER] ON
INSERT [dbo].[CUSTOMER] ([ID_CUSTOMER], [NAME_CUSTOMER], [CREATION_CUSTOMER], [PHONE_CUSTOMER], [ADDRESS_CUSTOMER], [EMAIL_CUSTOMER], [LATITUDE_CUSTOMER], [LONGITUDE_CUSTOMER]) VALUES (1, N'Customer 1', CAST(0x0000A12F013AC23E AS DateTime), N'72706724', N'Zona Itocta', N'rogerex@live.com', CAST(-17.3663673370 AS Decimal(18, 10)), CAST(-66.1761474609 AS Decimal(18, 10)))
INSERT [dbo].[CUSTOMER] ([ID_CUSTOMER], [NAME_CUSTOMER], [CREATION_CUSTOMER], [PHONE_CUSTOMER], [ADDRESS_CUSTOMER], [EMAIL_CUSTOMER], [LATITUDE_CUSTOMER], [LONGITUDE_CUSTOMER]) VALUES (2, N'Customer 2', CAST(0x0000A12F013CF477 AS DateTime), N'72706724', N'Barrio Concordia', N'customer2@live.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[CUSTOMER] OFF
/****** Object:  Table [dbo].[USER_ROLE]    Script Date: 12/22/2012 19:21:39 ******/
/****** Object:  Table [dbo].[PURCHASE_ORDER]    Script Date: 12/22/2012 19:21:39 ******/
/****** Object:  Table [dbo].[SESSION]    Script Date: 12/22/2012 19:21:39 ******/
/****** Object:  Table [dbo].[SALE_ORDER]    Script Date: 12/22/2012 19:21:39 ******/
/****** Object:  Table [dbo].[PERMISSION]    Script Date: 12/22/2012 19:21:39 ******/
/****** Object:  Table [dbo].[PAYMENT]    Script Date: 12/22/2012 19:21:39 ******/
/****** Object:  Table [dbo].[DETAIL_SALE]    Script Date: 12/22/2012 19:21:39 ******/
/****** Object:  Table [dbo].[DETAIL_PURCHASE]    Script Date: 12/22/2012 19:21:39 ******/
