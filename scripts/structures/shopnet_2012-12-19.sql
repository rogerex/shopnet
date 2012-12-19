/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     12/19/2012 10:56:39 AM                       */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETAIL_ORDER') and o.name = 'FK_DETAIL_O_DETAILS_P_PRODUCT')
alter table DETAIL_ORDER
   drop constraint FK_DETAIL_O_DETAILS_P_PRODUCT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETAIL_ORDER') and o.name = 'FK_DETAIL_O_DETAILS_S_SALE_ORD')
alter table DETAIL_ORDER
   drop constraint FK_DETAIL_O_DETAILS_S_SALE_ORD
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
   where r.fkeyid = object_id('STOCK') and o.name = 'FK_STOCK_PRODUCTS__PURCHASE')
alter table STOCK
   drop constraint FK_STOCK_PRODUCTS__PURCHASE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('STOCK') and o.name = 'FK_STOCK_STOCKS_PR_PRODUCT')
alter table STOCK
   drop constraint FK_STOCK_STOCKS_PR_PRODUCT
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
            from  sysobjects
           where  id = object_id('CUSTOMER')
            and   type = 'U')
   drop table CUSTOMER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETAIL_ORDER')
            and   name  = 'DETAILS_PRODUCT_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETAIL_ORDER.DETAILS_PRODUCT_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETAIL_ORDER')
            and   name  = 'DETAILS_SALE_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETAIL_ORDER.DETAILS_SALE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DETAIL_ORDER')
            and   type = 'U')
   drop table DETAIL_ORDER
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
            from  sysindexes
           where  id    = object_id('STOCK')
            and   name  = 'PRODUCTS_PURCHASE_FK'
            and   indid > 0
            and   indid < 255)
   drop index STOCK.PRODUCTS_PURCHASE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('STOCK')
            and   name  = 'STOCKS_PRODUCT_FK'
            and   indid > 0
            and   indid < 255)
   drop index STOCK.STOCKS_PRODUCT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('STOCK')
            and   type = 'U')
   drop table STOCK
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
/* Table: CUSTOMER                                              */
/*==============================================================*/
create table CUSTOMER (
   ID_CUSTOMER          numeric              identity,
   NAME_CUSTOMER        varchar(255)         not null,
   CREATION_CUSTOMER    datetime             not null,
   PHONE_CUSTOMER       varchar(255)         not null,
   ADDRESS_CUSTOMER     text                 not null,
   EMAIL_CUSTOMER       varchar(255)         not null,
   LATITUDE_CUSTOMER    decimal              null,
   LONGITUDE_CUSTOMER   decimal              null,
   constraint PK_CUSTOMER primary key nonclustered (ID_CUSTOMER)
)
go

/*==============================================================*/
/* Table: DETAIL_ORDER                                          */
/*==============================================================*/
create table DETAIL_ORDER (
   ID_SALE              numeric              not null,
   ID_PRODUCT           numeric              not null,
   PRICE_PRODUCT        decimal              not null,
   AMOUNT_PRODUCT       int                  not null,
   constraint PK_DETAIL_ORDER primary key (ID_SALE, ID_PRODUCT)
)
go

/*==============================================================*/
/* Index: DETAILS_SALE_FK                                       */
/*==============================================================*/
create index DETAILS_SALE_FK on DETAIL_ORDER (
ID_SALE ASC
)
go

/*==============================================================*/
/* Index: DETAILS_PRODUCT_FK                                    */
/*==============================================================*/
create index DETAILS_PRODUCT_FK on DETAIL_ORDER (
ID_PRODUCT ASC
)
go

/*==============================================================*/
/* Table: ITEM                                                  */
/*==============================================================*/
create table ITEM (
   ID_ITEM              numeric              identity,
   ID_PARENT_ITEM       numeric              null,
   DESC_ITEM            text                 not null,
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
   ID_PAYMENT           numeric              identity,
   ID_SALE              numeric              not null,
   MOUNT_PAYMENT        decimal              not null,
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
   ID_ITEM              numeric              not null,
   ID_ROLE              numeric              not null,
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
   ID_PRODUCT           numeric              identity,
   CODE_PRODUCT         varchar(255)         not null,
   NAME_PRODUCT         varchar(255)         not null,
   DESC_PRODUCT         text                 null,
   MINIMUM_PRODUCT      int                  null,
   constraint PK_PRODUCT primary key nonclustered (ID_PRODUCT)
)
go

/*==============================================================*/
/* Table: PROVIDER                                              */
/*==============================================================*/
create table PROVIDER (
   ID_PROVIDER          numeric              identity,
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
   ID_PURCHASE          numeric              identity,
   ID_PROVIDER          numeric              not null,
   ID_USER              numeric              not null,
   TOTAL_PURCHASE       decimal              not null,
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
   ID_ROLE              numeric              identity,
   NAME_ROLE            varchar(255)         not null,
   CREATION_ROLE        datetime             not null,
   constraint PK_ROLE primary key nonclustered (ID_ROLE)
)
go

/*==============================================================*/
/* Table: SALE_ORDER                                            */
/*==============================================================*/
create table SALE_ORDER (
   ID_SALE              numeric              identity,
   ID_CUSTOMER          numeric              not null,
   ID_TYPE_PAYMENT      numeric              not null,
   ID_USER              numeric              not null,
   CREATION_SALE        datetime             not null,
   TOTAL_SALE           decimal              not null,
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
   ID_SESSION           numeric              identity,
   ID_USER              numeric              not null,
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
/* Table: STOCK                                                 */
/*==============================================================*/
create table STOCK (
   ID_PRODUCT           numeric              not null,
   ID_PURCHASE          numeric              not null,
   AMOUNT_STOCK         int                  not null,
   COST_STOCK           decimal              not null,
   PRICE_STOCK          decimal              not null,
   CREATION_STOCK       datetime             not null,
   constraint PK_STOCK primary key nonclustered (ID_PRODUCT, ID_PURCHASE)
)
go

/*==============================================================*/
/* Index: STOCKS_PRODUCT_FK                                     */
/*==============================================================*/
create index STOCKS_PRODUCT_FK on STOCK (
ID_PRODUCT ASC
)
go

/*==============================================================*/
/* Index: PRODUCTS_PURCHASE_FK                                  */
/*==============================================================*/
create index PRODUCTS_PURCHASE_FK on STOCK (
ID_PURCHASE ASC
)
go

/*==============================================================*/
/* Table: TYPE_PAYMENT                                          */
/*==============================================================*/
create table TYPE_PAYMENT (
   ID_TYPE_PAYMENT      numeric              identity,
   DESC_TYPE_PAYMENT    text                 not null,
   AMOUNT_TYPE_PAYMENT  int                  not null,
   TOTAL_SALE_MINIMUM   decimal              null,
   constraint PK_TYPE_PAYMENT primary key nonclustered (ID_TYPE_PAYMENT)
)
go

/*==============================================================*/
/* Table: "USER"                                                */
/*==============================================================*/
create table "USER" (
   ID_USER              numeric              identity,
   NAME_USER            varchar(255)         not null,
   PASSWORD_USER        varchar(255)         not null,
   CREATION_USER        datetime             not null,
   STATUS_USER          int                  not null,
   constraint PK_USER primary key nonclustered (ID_USER)
)
go

/*==============================================================*/
/* Table: USER_ROLE                                             */
/*==============================================================*/
create table USER_ROLE (
   ID_ROLE              numeric              not null,
   ID_USER              numeric              not null,
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

alter table DETAIL_ORDER
   add constraint FK_DETAIL_O_DETAILS_P_PRODUCT foreign key (ID_PRODUCT)
      references PRODUCT (ID_PRODUCT)
go

alter table DETAIL_ORDER
   add constraint FK_DETAIL_O_DETAILS_S_SALE_ORD foreign key (ID_SALE)
      references SALE_ORDER (ID_SALE)
go

alter table ITEM
   add constraint FK_ITEM_PARENT_ITEM foreign key (ID_PARENT_ITEM)
      references ITEM (ID_ITEM)
go

alter table PAYMENT
   add constraint FK_PAYMENT_PAYMENTS__SALE_ORD foreign key (ID_SALE)
      references SALE_ORDER (ID_SALE)
go

alter table PERMISSION
   add constraint FK_PERMISSI_PERMISSIO_ITEM foreign key (ID_ITEM)
      references ITEM (ID_ITEM)
go

alter table PERMISSION
   add constraint FK_PERMISSI_PERMISSIO_ROLE foreign key (ID_ROLE)
      references ROLE (ID_ROLE)
go

alter table PURCHASE_ORDER
   add constraint FK_PURCHASE_PURCHASES_PROVIDER foreign key (ID_PROVIDER)
      references PROVIDER (ID_PROVIDER)
go

alter table PURCHASE_ORDER
   add constraint FK_PURCHASE_PURCHASES_USER foreign key (ID_USER)
      references "USER" (ID_USER)
go

alter table SALE_ORDER
   add constraint FK_SALE_ORD_ORDERS_CU_CUSTOMER foreign key (ID_CUSTOMER)
      references CUSTOMER (ID_CUSTOMER)
go

alter table SALE_ORDER
   add constraint FK_SALE_ORD_SALES_TYP_TYPE_PAY foreign key (ID_TYPE_PAYMENT)
      references TYPE_PAYMENT (ID_TYPE_PAYMENT)
go

alter table SALE_ORDER
   add constraint FK_SALE_ORD_SALES_USE_USER foreign key (ID_USER)
      references "USER" (ID_USER)
go

alter table SESSION
   add constraint FK_SESSION_SESSIONS__USER foreign key (ID_USER)
      references "USER" (ID_USER)
go

alter table STOCK
   add constraint FK_STOCK_PRODUCTS__PURCHASE foreign key (ID_PURCHASE)
      references PURCHASE_ORDER (ID_PURCHASE)
go

alter table STOCK
   add constraint FK_STOCK_STOCKS_PR_PRODUCT foreign key (ID_PRODUCT)
      references PRODUCT (ID_PRODUCT)
go

alter table USER_ROLE
   add constraint FK_USER_ROL_ROLES_USE_USER foreign key (ID_USER)
      references "USER" (ID_USER)
go

alter table USER_ROLE
   add constraint FK_USER_ROL_USERS_ROL_ROLE foreign key (ID_ROLE)
      references ROLE (ID_ROLE)
go

