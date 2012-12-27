/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     12/24/2012 11:36:06 AM                       */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CART_ITEM') and o.name = 'FK_CART_ITE_CART_ITEM_PRODUCT')
alter table CART_ITEM
   drop constraint FK_CART_ITE_CART_ITEM_PRODUCT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETAIL_PURCHASE') and o.name = 'FK_DETAIL_P_PRODUCTS__PURCHASE')
alter table DETAIL_PURCHASE
   drop constraint FK_DETAIL_P_PRODUCTS__PURCHASE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETAIL_PURCHASE') and o.name = 'FK_DETAIL_P_PURCHASES_PRODUCT')
alter table DETAIL_PURCHASE
   drop constraint FK_DETAIL_P_PURCHASES_PRODUCT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETAIL_SALE') and o.name = 'FK_DETAIL_S_DETAILS_P_PRODUCT')
alter table DETAIL_SALE
   drop constraint FK_DETAIL_S_DETAILS_P_PRODUCT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETAIL_SALE') and o.name = 'FK_DETAIL_S_DETAILS_S_SALE_ORD')
alter table DETAIL_SALE
   drop constraint FK_DETAIL_S_DETAILS_S_SALE_ORD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ITEM') and o.name = 'FK_ITEM_PARENT_ITEM')
alter table ITEM
   drop constraint FK_ITEM_PARENT_ITEM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PAYMENT') and o.name = 'FK_PAYMENT_PAYMENTS__SALE_ORD')
alter table PAYMENT
   drop constraint FK_PAYMENT_PAYMENTS__SALE_ORD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PERMISSION') and o.name = 'FK_PERMISSI_PERMISSIO_ITEM')
alter table PERMISSION
   drop constraint FK_PERMISSI_PERMISSIO_ITEM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PERMISSION') and o.name = 'FK_PERMISSI_PERMISSIO_ROLE')
alter table PERMISSION
   drop constraint FK_PERMISSI_PERMISSIO_ROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PURCHASE_ORDER') and o.name = 'FK_PURCHASE_PURCHASES_PROVIDER')
alter table PURCHASE_ORDER
   drop constraint FK_PURCHASE_PURCHASES_PROVIDER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PURCHASE_ORDER') and o.name = 'FK_PURCHASE_PURCHASES_USER')
alter table PURCHASE_ORDER
   drop constraint FK_PURCHASE_PURCHASES_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SALE_ORDER') and o.name = 'FK_SALE_ORD_ORDERS_CU_CUSTOMER')
alter table SALE_ORDER
   drop constraint FK_SALE_ORD_ORDERS_CU_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SALE_ORDER') and o.name = 'FK_SALE_ORD_SALES_TYP_TYPE_PAY')
alter table SALE_ORDER
   drop constraint FK_SALE_ORD_SALES_TYP_TYPE_PAY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SALE_ORDER') and o.name = 'FK_SALE_ORD_SALES_USE_USER')
alter table SALE_ORDER
   drop constraint FK_SALE_ORD_SALES_USE_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SESSION') and o.name = 'FK_SESSION_SESSIONS__USER')
alter table SESSION
   drop constraint FK_SESSION_SESSIONS__USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USER_ROLE') and o.name = 'FK_USER_ROL_ROLES_USE_USER')
alter table USER_ROLE
   drop constraint FK_USER_ROL_ROLES_USE_USER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USER_ROLE') and o.name = 'FK_USER_ROL_USERS_ROL_ROLE')
alter table USER_ROLE
   drop constraint FK_USER_ROL_USERS_ROL_ROLE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CART_ITEM')
            and   name  = 'CART_ITEMS_PRODUCT_FK'
            and   indid > 0
            and   indid < 255)
   drop index CART_ITEM.CART_ITEMS_PRODUCT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CART_ITEM')
            and   type = 'U')
   drop table CART_ITEM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CUSTOMER')
            and   type = 'U')
   drop table CUSTOMER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETAIL_PURCHASE')
            and   name  = 'PRODUCTS_PURCHASE_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETAIL_PURCHASE.PRODUCTS_PURCHASE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETAIL_PURCHASE')
            and   name  = 'PURCHASES_PRODUCT_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETAIL_PURCHASE.PURCHASES_PRODUCT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DETAIL_PURCHASE')
            and   type = 'U')
   drop table DETAIL_PURCHASE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETAIL_SALE')
            and   name  = 'DETAILS_PRODUCT_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETAIL_SALE.DETAILS_PRODUCT_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETAIL_SALE')
            and   name  = 'DETAILS_SALE_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETAIL_SALE.DETAILS_SALE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DETAIL_SALE')
            and   type = 'U')
   drop table DETAIL_SALE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ITEM')
            and   name  = 'PARENT_FK'
            and   indid > 0
            and   indid < 255)
   drop index ITEM.PARENT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ITEM')
            and   type = 'U')
   drop table ITEM
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PAYMENT')
            and   name  = 'PAYMENTS_SALE_ORDER_FK'
            and   indid > 0
            and   indid < 255)
   drop index PAYMENT.PAYMENTS_SALE_ORDER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PAYMENT')
            and   type = 'U')
   drop table PAYMENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PERMISSION')
            and   name  = 'PERMISSIONS_ROLE_FK'
            and   indid > 0
            and   indid < 255)
   drop index PERMISSION.PERMISSIONS_ROLE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PERMISSION')
            and   name  = 'PERMISSIONS_ITEM_FK'
            and   indid > 0
            and   indid < 255)
   drop index PERMISSION.PERMISSIONS_ITEM_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PERMISSION')
            and   type = 'U')
   drop table PERMISSION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCT')
            and   type = 'U')
   drop table PRODUCT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PROVIDER')
            and   type = 'U')
   drop table PROVIDER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PURCHASE_ORDER')
            and   name  = 'PURCHASES_USER_FK'
            and   indid > 0
            and   indid < 255)
   drop index PURCHASE_ORDER.PURCHASES_USER_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PURCHASE_ORDER')
            and   name  = 'PURCHASES_PROVIDER_FK'
            and   indid > 0
            and   indid < 255)
   drop index PURCHASE_ORDER.PURCHASES_PROVIDER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PURCHASE_ORDER')
            and   type = 'U')
   drop table PURCHASE_ORDER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ROLE')
            and   type = 'U')
   drop table ROLE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SALE_ORDER')
            and   name  = 'SALES_USER_FK'
            and   indid > 0
            and   indid < 255)
   drop index SALE_ORDER.SALES_USER_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SALE_ORDER')
            and   name  = 'SALES_TYPE_PAYMENT_FK'
            and   indid > 0
            and   indid < 255)
   drop index SALE_ORDER.SALES_TYPE_PAYMENT_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SALE_ORDER')
            and   name  = 'ORDERS_CUSTOMER_FK'
            and   indid > 0
            and   indid < 255)
   drop index SALE_ORDER.ORDERS_CUSTOMER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SALE_ORDER')
            and   type = 'U')
   drop table SALE_ORDER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SESSION')
            and   name  = 'SESSIONS_USER_FK'
            and   indid > 0
            and   indid < 255)
   drop index SESSION.SESSIONS_USER_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SESSION')
            and   type = 'U')
   drop table SESSION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TYPE_PAYMENT')
            and   type = 'U')
   drop table TYPE_PAYMENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"USER"')
            and   type = 'U')
   drop table "USER"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('USER_ROLE')
            and   name  = 'ROLES_USER_FK'
            and   indid > 0
            and   indid < 255)
   drop index USER_ROLE.ROLES_USER_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('USER_ROLE')
            and   name  = 'USERS_ROLE_FK'
            and   indid > 0
            and   indid < 255)
   drop index USER_ROLE.USERS_ROLE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USER_ROLE')
            and   type = 'U')
   drop table USER_ROLE
go

/*==============================================================*/
/* Table: CART_ITEM                                             */
/*==============================================================*/
create table CART_ITEM (
   ID_CART_ITEM         int              identity,
   ID_PRODUCT           int              not null,
   ID_CART              varchar(63)          not null,
   PRICE_CART_ITEM      decimal(18,10)       not null,
   AMOUNT_CART_ITEM     int                  not null,
   CREATION_CART_ITEM   datetime             not null,
   constraint PK_CART_ITEM primary key nonclustered (ID_CART_ITEM)
)
go

/*==============================================================*/
/* Index: CART_ITEMS_PRODUCT_FK                                 */
/*==============================================================*/
create index CART_ITEMS_PRODUCT_FK on CART_ITEM (
ID_PRODUCT ASC
)
go

/*==============================================================*/
/* Table: CUSTOMER                                              */
/*==============================================================*/
create table CUSTOMER (
   ID_CUSTOMER          int              identity,
   NAME_CUSTOMER        varchar(255)         not null,
   CREATION_CUSTOMER    datetime             not null,
   PHONE_CUSTOMER       varchar(255)         not null,
   ADDRESS_CUSTOMER     text                 not null,
   EMAIL_CUSTOMER       varchar(255)         not null,
   LATITUDE_CUSTOMER    decimal(18,10)       null,
   LONGITUDE_CUSTOMER   decimal(18,10)       null,
   constraint PK_CUSTOMER primary key nonclustered (ID_CUSTOMER)
)
go

/*==============================================================*/
/* Table: DETAIL_PURCHASE                                       */
/*==============================================================*/
create table DETAIL_PURCHASE (
   ID_PRODUCT           int              not null,
   ID_PURCHASE          int              not null,
   CURRENT_AMOUNT_PURCHASE int                  not null,
   TOTAL_AMOUNT_PURCHASE int                  not null,
   COST_PURCHASE        decimal(18,10)       not null,
   PRICE_PURCHASE       decimal(18,10)       not null,
   constraint PK_DETAIL_PURCHASE primary key (ID_PRODUCT, ID_PURCHASE)
)
go

/*==============================================================*/
/* Index: PURCHASES_PRODUCT_FK                                  */
/*==============================================================*/
create index PURCHASES_PRODUCT_FK on DETAIL_PURCHASE (
ID_PRODUCT ASC
)
go

/*==============================================================*/
/* Index: PRODUCTS_PURCHASE_FK                                  */
/*==============================================================*/
create index PRODUCTS_PURCHASE_FK on DETAIL_PURCHASE (
ID_PURCHASE ASC
)
go

/*==============================================================*/
/* Table: DETAIL_SALE                                           */
/*==============================================================*/
create table DETAIL_SALE (
   ID_SALE              int              not null,
   ID_PRODUCT           int              not null,
   PRICE_SALE           decimal(18,10)       not null,
   AMOUNT_SALE          int                  not null,
   constraint PK_DETAIL_SALE primary key (ID_SALE, ID_PRODUCT)
)
go

/*==============================================================*/
/* Index: DETAILS_SALE_FK                                       */
/*==============================================================*/
create index DETAILS_SALE_FK on DETAIL_SALE (
ID_SALE ASC
)
go

/*==============================================================*/
/* Index: DETAILS_PRODUCT_FK                                    */
/*==============================================================*/
create index DETAILS_PRODUCT_FK on DETAIL_SALE (
ID_PRODUCT ASC
)
go

/*==============================================================*/
/* Table: ITEM                                                  */
/*==============================================================*/
create table ITEM (
   ID_ITEM              int              identity,
   ID_PARENT_ITEM       int              null,
   NAME_ITEM            varchar(255)         not null,
   DESC_ITEM            text                 null,
   PATH_ITEM            varchar(255)         not null,
   constraint PK_ITEM primary key nonclustered (ID_ITEM)
)
go

/*==============================================================*/
/* Index: PARENT_FK                                             */
/*==============================================================*/
create index PARENT_FK on ITEM (
ID_PARENT_ITEM ASC
)
go

/*==============================================================*/
/* Table: PAYMENT                                               */
/*==============================================================*/
create table PAYMENT (
   ID_PAYMENT           int              identity,
   ID_SALE              int              not null,
   MOUNT_PAYMENT        decimal(18,10)       not null,
   CREATION_PAYMENT     datetime             not null,
   constraint PK_PAYMENT primary key nonclustered (ID_PAYMENT)
)
go

/*==============================================================*/
/* Index: PAYMENTS_SALE_ORDER_FK                                */
/*==============================================================*/
create index PAYMENTS_SALE_ORDER_FK on PAYMENT (
ID_SALE ASC
)
go

/*==============================================================*/
/* Table: PERMISSION                                            */
/*==============================================================*/
create table PERMISSION (
   ID_ITEM              int              not null,
   ID_ROLE              int              not null,
   constraint PK_PERMISSION primary key (ID_ITEM, ID_ROLE)
)
go

/*==============================================================*/
/* Index: PERMISSIONS_ITEM_FK                                   */
/*==============================================================*/
create index PERMISSIONS_ITEM_FK on PERMISSION (
ID_ITEM ASC
)
go

/*==============================================================*/
/* Index: PERMISSIONS_ROLE_FK                                   */
/*==============================================================*/
create index PERMISSIONS_ROLE_FK on PERMISSION (
ID_ROLE ASC
)
go

/*==============================================================*/
/* Table: PRODUCT                                               */
/*==============================================================*/
create table PRODUCT (
   ID_PRODUCT           int              identity,
   CODE_PRODUCT         varchar(255)         not null,
   NAME_PRODUCT         varchar(255)         not null,
   DESC_PRODUCT         text                 null,
   MINIMUM_PRODUCT      int                  null,
   CREATION_PRODUCT     datetime             not null,
   PRICE_PRODUCT        decimal(18,10)       not null,
   IMAGE_URL_PRODUCT    varchar(255)         null,
   constraint PK_PRODUCT primary key nonclustered (ID_PRODUCT)
)
go

/*==============================================================*/
/* Table: PROVIDER                                              */
/*==============================================================*/
create table PROVIDER (
   ID_PROVIDER          int              identity,
   NAME_PROVIDER        varchar(255)         not null,
   DESC_PROVIDER        text                 null,
   CREATION_PROVIDER    datetime             not null,
   ADDRESS_PROVIDER     varchar(255)         null,
   PHONE_PROVIDER       varchar(255)         null,
   constraint PK_PROVIDER primary key nonclustered (ID_PROVIDER)
)
go

/*==============================================================*/
/* Table: PURCHASE_ORDER                                        */
/*==============================================================*/
create table PURCHASE_ORDER (
   ID_PURCHASE          int              identity,
   ID_PROVIDER          int              not null,
   ID_USER              int              not null,
   TOTAL_PURCHASE       decimal(18,10)       not null,
   CREATION_PURCHASE    datetime             not null,
   constraint PK_PURCHASE_ORDER primary key nonclustered (ID_PURCHASE)
)
go

/*==============================================================*/
/* Index: PURCHASES_PROVIDER_FK                                 */
/*==============================================================*/
create index PURCHASES_PROVIDER_FK on PURCHASE_ORDER (
ID_PROVIDER ASC
)
go

/*==============================================================*/
/* Index: PURCHASES_USER_FK                                     */
/*==============================================================*/
create index PURCHASES_USER_FK on PURCHASE_ORDER (
ID_USER ASC
)
go

/*==============================================================*/
/* Table: ROLE                                                  */
/*==============================================================*/
create table ROLE (
   ID_ROLE              int              identity,
   NAME_ROLE            varchar(255)         not null,
   CREATION_ROLE        datetime             not null,
   constraint PK_ROLE primary key nonclustered (ID_ROLE)
)
go

/*==============================================================*/
/* Table: SALE_ORDER                                            */
/*==============================================================*/
create table SALE_ORDER (
   ID_SALE              int              identity,
   ID_CUSTOMER          int              not null,
   ID_TYPE_PAYMENT      int              not null,
   ID_USER              int              not null,
   CREATION_SALE        datetime             not null,
   TOTAL_SALE           decimal(18,10)       not null,
   constraint PK_SALE_ORDER primary key nonclustered (ID_SALE)
)
go

/*==============================================================*/
/* Index: ORDERS_CUSTOMER_FK                                    */
/*==============================================================*/
create index ORDERS_CUSTOMER_FK on SALE_ORDER (
ID_CUSTOMER ASC
)
go

/*==============================================================*/
/* Index: SALES_TYPE_PAYMENT_FK                                 */
/*==============================================================*/
create index SALES_TYPE_PAYMENT_FK on SALE_ORDER (
ID_TYPE_PAYMENT ASC
)
go

/*==============================================================*/
/* Index: SALES_USER_FK                                         */
/*==============================================================*/
create index SALES_USER_FK on SALE_ORDER (
ID_USER ASC
)
go

/*==============================================================*/
/* Table: SESSION                                               */
/*==============================================================*/
create table SESSION (
   ID_SESSION           int              identity,
   ID_USER              int              not null,
   INIT_SESSION         datetime             not null,
   END_SESSION          datetime             null,
   STATUS_SESSION       int                  not null,
   constraint PK_SESSION primary key nonclustered (ID_SESSION)
)
go

/*==============================================================*/
/* Index: SESSIONS_USER_FK                                      */
/*==============================================================*/
create index SESSIONS_USER_FK on SESSION (
ID_USER ASC
)
go

/*==============================================================*/
/* Table: TYPE_PAYMENT                                          */
/*==============================================================*/
create table TYPE_PAYMENT (
   ID_TYPE_PAYMENT      int              identity,
   NAME_TYPE_PAYMENT    varchar(255)         not null,
   STATUS_TYPE_PAYMENT  int                  not null,
   DESC_TYPE_PAYMENT    text                 null,
   AMOUNT_TYPE_PAYMENT  int                  null,
   TOTAL_SALE_MINIMUM   decimal(18,10)       null,
   constraint PK_TYPE_PAYMENT primary key nonclustered (ID_TYPE_PAYMENT)
)
go

/*==============================================================*/
/* Table: "USER"                                                */
/*==============================================================*/
create table "USER" (
   ID_USER              int              identity,
   NAME_USER            varchar(255)         not null,
   PASSWORD_USER        varchar(255)         not null,
   EMAIL_USER           varchar(255)         not null,
   CREATION_USER        datetime             not null,
   STATUS_USER          int                  not null,
   constraint PK_USER primary key nonclustered (ID_USER)
)
go

/*==============================================================*/
/* Table: USER_ROLE                                             */
/*==============================================================*/
create table USER_ROLE (
   ID_ROLE              int              not null,
   ID_USER              int              not null,
   constraint PK_USER_ROLE primary key (ID_ROLE, ID_USER)
)
go

/*==============================================================*/
/* Index: USERS_ROLE_FK                                         */
/*==============================================================*/
create index USERS_ROLE_FK on USER_ROLE (
ID_ROLE ASC
)
go

/*==============================================================*/
/* Index: ROLES_USER_FK                                         */
/*==============================================================*/
create index ROLES_USER_FK on USER_ROLE (
ID_USER ASC
)
go

alter table CART_ITEM
   add constraint FK_CART_ITE_CART_ITEM_PRODUCT foreign key (ID_PRODUCT)
      references PRODUCT (ID_PRODUCT)
         on update cascade on delete cascade
go

alter table DETAIL_PURCHASE
   add constraint FK_DETAIL_P_PRODUCTS__PURCHASE foreign key (ID_PURCHASE)
      references PURCHASE_ORDER (ID_PURCHASE)
         on update cascade on delete cascade
go

alter table DETAIL_PURCHASE
   add constraint FK_DETAIL_P_PURCHASES_PRODUCT foreign key (ID_PRODUCT)
      references PRODUCT (ID_PRODUCT)
         on update cascade on delete cascade
go

alter table DETAIL_SALE
   add constraint FK_DETAIL_S_DETAILS_P_PRODUCT foreign key (ID_PRODUCT)
      references PRODUCT (ID_PRODUCT)
         on update cascade on delete cascade
go

alter table DETAIL_SALE
   add constraint FK_DETAIL_S_DETAILS_S_SALE_ORD foreign key (ID_SALE)
      references SALE_ORDER (ID_SALE)
         on update cascade on delete cascade
go

alter table ITEM
   add constraint FK_ITEM_PARENT_ITEM foreign key (ID_PARENT_ITEM)
      references ITEM (ID_ITEM)
go

alter table PAYMENT
   add constraint FK_PAYMENT_PAYMENTS__SALE_ORD foreign key (ID_SALE)
      references SALE_ORDER (ID_SALE)
         on update cascade on delete cascade
go

alter table PERMISSION
   add constraint FK_PERMISSI_PERMISSIO_ITEM foreign key (ID_ITEM)
      references ITEM (ID_ITEM)
         on update cascade on delete cascade
go

alter table PERMISSION
   add constraint FK_PERMISSI_PERMISSIO_ROLE foreign key (ID_ROLE)
      references ROLE (ID_ROLE)
         on update cascade on delete cascade
go

alter table PURCHASE_ORDER
   add constraint FK_PURCHASE_PURCHASES_PROVIDER foreign key (ID_PROVIDER)
      references PROVIDER (ID_PROVIDER)
         on update cascade on delete cascade
go

alter table PURCHASE_ORDER
   add constraint FK_PURCHASE_PURCHASES_USER foreign key (ID_USER)
      references "USER" (ID_USER)
         on update cascade on delete cascade
go

alter table SALE_ORDER
   add constraint FK_SALE_ORD_ORDERS_CU_CUSTOMER foreign key (ID_CUSTOMER)
      references CUSTOMER (ID_CUSTOMER)
         on update cascade on delete cascade
go

alter table SALE_ORDER
   add constraint FK_SALE_ORD_SALES_TYP_TYPE_PAY foreign key (ID_TYPE_PAYMENT)
      references TYPE_PAYMENT (ID_TYPE_PAYMENT)
         on update cascade on delete cascade
go

alter table SALE_ORDER
   add constraint FK_SALE_ORD_SALES_USE_USER foreign key (ID_USER)
      references "USER" (ID_USER)
         on update cascade on delete cascade
go

alter table SESSION
   add constraint FK_SESSION_SESSIONS__USER foreign key (ID_USER)
      references "USER" (ID_USER)
         on update cascade on delete cascade
go

alter table USER_ROLE
   add constraint FK_USER_ROL_ROLES_USE_USER foreign key (ID_USER)
      references "USER" (ID_USER)
         on update cascade on delete cascade
go

alter table USER_ROLE
   add constraint FK_USER_ROL_USERS_ROL_ROLE foreign key (ID_ROLE)
      references ROLE (ID_ROLE)
         on update cascade on delete cascade
go

