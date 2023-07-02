using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MU.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Account = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: true),
                    VaultCount = table.Column<int>(type: "integer", nullable: false),
                    VaultMoney = table.Column<int>(type: "integer", nullable: false),
                    ServerCode = table.Column<int>(type: "integer", nullable: false),
                    IsConnected = table.Column<bool>(type: "TINYINT(1)", nullable: false),
                    LastConnection = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AuthToken = table.Column<string>(type: "character varying(33)", maxLength: 33, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Guild",
                columns: table => new
                {
                    GuildId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AllianceId = table.Column<int>(type: "integer", nullable: true),
                    Mark = table.Column<byte[]>(type: "bytea", nullable: true),
                    GuildType = table.Column<byte>(type: "smallint", nullable: false),
                    Rival1 = table.Column<int>(type: "integer", nullable: true),
                    Rival2 = table.Column<int>(type: "integer", nullable: true),
                    Rival3 = table.Column<int>(type: "integer", nullable: true),
                    Rival4 = table.Column<int>(type: "integer", nullable: true),
                    Rival5 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guild", x => x.GuildId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<long>(type: "BIGINT(5)", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    VaultId = table.Column<int>(type: "integer", nullable: false),
                    SlotId = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "SMALLINT(5) UNSIGNED", nullable: false),
                    Plus = table.Column<byte>(type: "smallint", nullable: false),
                    Luck = table.Column<bool>(type: "TINYINT(1)", nullable: false),
                    Skill = table.Column<bool>(type: "TINYINT(1)", nullable: false),
                    Durability = table.Column<byte>(type: "TINYINT(1) UNSIGNED", nullable: false),
                    Option = table.Column<byte>(type: "TINYINT(1) UNSIGNED", nullable: false),
                    OptionExe = table.Column<byte>(type: "TINYINT(1) UNSIGNED", nullable: false),
                    HarmonyOption = table.Column<byte>(type: "TINYINT(1) UNSIGNED", nullable: false),
                    SocketOptions = table.Column<string>(type: "text", nullable: true),
                    SocketBonus = table.Column<byte>(type: "TINYINT(1) UNSIGNED", nullable: false),
                    PJewels = table.Column<string>(type: "text", nullable: true),
                    PetLevel = table.Column<byte>(type: "SMALLINT(5) UNSIGNED", nullable: false),
                    PetEXP = table.Column<long>(type: "BIGINT(5)", nullable: false),
                    SetOption = table.Column<byte>(type: "TINYINT(1) UNSIGNED", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "MasterInfo",
                columns: table => new
                {
                    MasterInfoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<int>(type: "SMALLINT(5) UNSIGNED", nullable: false),
                    Experience = table.Column<long>(type: "BIGINT UNSIGNED", nullable: false),
                    Points = table.Column<int>(type: "SMALLINT(5) UNSIGNED", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterInfo", x => x.MasterInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Sell",
                columns: table => new
                {
                    Index = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Item = table.Column<byte[]>(type: "bytea", maxLength: 12, nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<short>(type: "SMALLINT(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sell", x => x.Index);
                });

            migrationBuilder.CreateTable(
                name: "SkillKey",
                columns: table => new
                {
                    SkillKeyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SkillKey = table.Column<byte[]>(type: "bytea", nullable: true),
                    GameOption = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false),
                    QkeyDefine = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false),
                    WkeyDefine = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false),
                    EkeyDefine = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false),
                    ChatWindow = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false),
                    RkeyDefine = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false),
                    QWERLevelDefine = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillKey", x => x.SkillKeyId);
                });

            migrationBuilder.CreateTable(
                name: "GremoryCase",
                columns: table => new
                {
                    GiftId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    Inventory = table.Column<byte>(type: "smallint", nullable: false),
                    Source = table.Column<byte>(type: "smallint", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: true),
                    Auth = table.Column<long>(type: "bigint", nullable: false),
                    ItemNumber = table.Column<int>(type: "SMALLINT(5) UNSIGNED", nullable: false),
                    Plus = table.Column<byte>(type: "smallint", nullable: false),
                    Luck = table.Column<bool>(type: "TINYINT(1)", nullable: false),
                    Skill = table.Column<bool>(type: "TINYINT(1)", nullable: false),
                    Durability = table.Column<byte>(type: "TINYINT(1) UNSIGNED", nullable: false),
                    Option = table.Column<byte>(type: "TINYINT(1) UNSIGNED", nullable: false),
                    OptionExe = table.Column<byte>(type: "TINYINT(1) UNSIGNED", nullable: false),
                    HarmonyOption = table.Column<byte>(type: "TINYINT(1) UNSIGNED", nullable: false),
                    SocketOptions = table.Column<string>(type: "text", nullable: true),
                    ExpireTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GremoryCase", x => x.GiftId);
                    table.ForeignKey(
                        name: "FK_GremoryCase_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuildMatching",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GuildId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    InterestType = table.Column<short>(type: "smallint", nullable: false),
                    LevelRange = table.Column<short>(type: "smallint", nullable: false),
                    Class = table.Column<short>(type: "SMALLINT(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildMatching", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildMatching_Guild_GuildId",
                        column: x => x.GuildId,
                        principalTable: "Guild",
                        principalColumn: "GuildId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Class = table.Column<int>(type: "integer", nullable: false),
                    CtlCode = table.Column<int>(type: "integer", nullable: false),
                    GuildId = table.Column<int>(type: "integer", nullable: true),
                    Map = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    X = table.Column<short>(type: "smallint", nullable: false),
                    Y = table.Column<short>(type: "smallint", nullable: false),
                    Level = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    Life = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    MaxLife = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    Mana = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    MaxMana = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    Experience = table.Column<long>(type: "bigint", nullable: false),
                    LevelUpPoints = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    Str = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    Agility = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    Vitality = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    Energy = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    Command = table.Column<short>(type: "SMALLINT(5)", nullable: false),
                    Money = table.Column<int>(type: "INT(11)", nullable: false),
                    Ruud = table.Column<int>(type: "INT(11)", nullable: false),
                    ExpandedInventory = table.Column<byte>(type: "smallint", nullable: false),
                    PKLevel = table.Column<short>(type: "smallint", nullable: false),
                    PKTime = table.Column<int>(type: "integer", nullable: false),
                    SkillKeyId = table.Column<int>(type: "integer", nullable: true),
                    MasterInfoId = table.Column<int>(type: "integer", nullable: true),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    Resets = table.Column<int>(type: "SMALLINT(5) UNSIGNED", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Character_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Guild_GuildId",
                        column: x => x.GuildId,
                        principalTable: "Guild",
                        principalColumn: "GuildId");
                    table.ForeignKey(
                        name: "FK_Character_MasterInfo_MasterInfoId",
                        column: x => x.MasterInfoId,
                        principalTable: "MasterInfo",
                        principalColumn: "MasterInfoId");
                    table.ForeignKey(
                        name: "FK_Character_SkillKey_SkillKeyId",
                        column: x => x.SkillKeyId,
                        principalTable: "SkillKey",
                        principalColumn: "SkillKeyId");
                });

            migrationBuilder.CreateTable(
                name: "BloodCastle",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodCastle", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_BloodCastle_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoritesList",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Fav01 = table.Column<int>(type: "integer", nullable: false),
                    Fav02 = table.Column<int>(type: "integer", nullable: false),
                    Fav03 = table.Column<int>(type: "integer", nullable: false),
                    Fav04 = table.Column<int>(type: "integer", nullable: false),
                    Fav05 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritesList", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_FavoritesList_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    FriendId = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_Character_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gens",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Influence = table.Column<int>(type: "integer", nullable: false),
                    Class = table.Column<int>(type: "integer", nullable: false),
                    Ranking = table.Column<int>(type: "integer", nullable: false),
                    Contribution = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gens", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Gens_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuildMatchingJoin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GuildMatchingId = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildMatchingJoin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildMatchingJoin_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuildMatchingJoin_GuildMatching_GuildMatchingId",
                        column: x => x.GuildMatchingId,
                        principalTable: "GuildMatching",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuildMember",
                columns: table => new
                {
                    MembId = table.Column<int>(type: "integer", nullable: false),
                    GuildId = table.Column<int>(type: "integer", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildMember", x => x.MembId);
                    table.ForeignKey(
                        name: "FK_GuildMember_Character_MembId",
                        column: x => x.MembId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuildMember_Guild_GuildId",
                        column: x => x.GuildId,
                        principalTable: "Guild",
                        principalColumn: "GuildId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hunting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Map = table.Column<int>(type: "SMALLINT(5) UNSIGNED", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Level = table.Column<int>(type: "SMALLINT(5) UNSIGNED", nullable: false),
                    Experience = table.Column<long>(type: "bigint", nullable: false),
                    HealingUse = table.Column<float>(type: "real", nullable: false),
                    AttackPVM = table.Column<long>(type: "bigint", nullable: false),
                    ElementalAttackPVM = table.Column<long>(type: "bigint", nullable: false),
                    KilledMonsters = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hunting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hunting_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Letters",
                columns: table => new
                {
                    MemoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Subject = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.MemoId);
                    table.ForeignKey(
                        name: "FK_Letters_Character_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    QuestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quest = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<byte>(type: "smallint", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: true),
                    CharacterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quest", x => x.QuestId);
                    table.ForeignKey(
                        name: "FK_Quest_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestEX",
                columns: table => new
                {
                    QuestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quest = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestEX", x => x.QuestId);
                    table.ForeignKey(
                        name: "FK_QuestEX_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    SpellId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    Magic = table.Column<short>(type: "smallint", nullable: false),
                    Level = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.SpellId);
                    table.ForeignKey(
                        name: "FK_Spells_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_AccountId",
                table: "Character",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_GuildId",
                table: "Character",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_MasterInfoId",
                table: "Character",
                column: "MasterInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_SkillKeyId",
                table: "Character",
                column: "SkillKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_CharacterId",
                table: "Friends",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendId",
                table: "Friends",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_GremoryCase_AccountId",
                table: "GremoryCase",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GuildMatching_GuildId",
                table: "GuildMatching",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_GuildMatchingJoin_CharacterId",
                table: "GuildMatchingJoin",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_GuildMatchingJoin_GuildMatchingId",
                table: "GuildMatchingJoin",
                column: "GuildMatchingId");

            migrationBuilder.CreateIndex(
                name: "IX_GuildMember_GuildId",
                table: "GuildMember",
                column: "GuildId");

            migrationBuilder.CreateIndex(
                name: "IX_Hunting_CharacterId",
                table: "Hunting",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Letters_SenderId",
                table: "Letters",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Quest_CharacterId",
                table: "Quest",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestEX_CharacterId",
                table: "QuestEX",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_CharacterId",
                table: "Spells",
                column: "CharacterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodCastle");

            migrationBuilder.DropTable(
                name: "FavoritesList");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Gens");

            migrationBuilder.DropTable(
                name: "GremoryCase");

            migrationBuilder.DropTable(
                name: "GuildMatchingJoin");

            migrationBuilder.DropTable(
                name: "GuildMember");

            migrationBuilder.DropTable(
                name: "Hunting");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Letters");

            migrationBuilder.DropTable(
                name: "Quest");

            migrationBuilder.DropTable(
                name: "QuestEX");

            migrationBuilder.DropTable(
                name: "Sell");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "GuildMatching");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Guild");

            migrationBuilder.DropTable(
                name: "MasterInfo");

            migrationBuilder.DropTable(
                name: "SkillKey");
        }
    }
}
