﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopUI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetail_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Mobile" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Laptop" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "PC" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "سامسونگ Galaxy A13 یکی از گوشی‌های هوشمند میان‌رده جدید سامسونگ است که به نسبت پارت‌نامبر قبلی خود، در برخی از مشخصات فنی تفاوت‌هایی با یکدیگر دارند. در نمای رو‌به‌رویی این گوشی به صفحه‌نمایش با ابعاد 6.6 اینچ و رزولوشن 1080×2408 پیکسل از نوع PLS مجهز شده که توانایی نمایش 400 پیکسل در هر اینچ را دارد. طراحی ناچ واتردراپ یا همان اینفینیتی U برای این صفحه‌نمایش در نظر گرفته شده است که بریدگی قطره‌ای شکل ناچ در قسمت بالایی و مرکزی صفحه‌نمایش، سنسور دوربین سلفی با رزولوشن 8 مگاپی ...\r\n", "گوشی موبایل سامسونگ مدل Galaxy A13 دو سیم کارت ظرفیت 64 گیگابایت و رم 4 گیگابایت به همراه شارژر\r\n", 7000000 },
                    { 2, 1, "گوشی موبایل iPhone 13 CH پرچم‌دار جدید شرکت اپل است که با چند ویژگی جدید و دوربین دوگانه روانه بازار شده است. نمایشگر آیفون 13 به پنل Super Retina مجهز ‌شده است تا تصاویر بسیار مطلوبی را به کاربر عرضه کند. این نمایشگر رزولوشن بسیار بالایی دارد؛ به‌طوری‌که در اندازه­‌ی 6.1 اینچی‌اش، حدود 460 پیکسل را در هر اینچ جا داده است. امکان شارژ بی‌‌سیم باتری در این گوشی وجود دارد. تشخیص چهره با استفاده از دوربین جلو دیگر ویژگی است که در آیفون جدید اپل به کار گرفته شده است. از نظر سخت‌‌ا ...\r\n", "گوشی موبایل اپل مدل iPhone 13 CH دو سیم‌ کارت ظرفیت 128 گیگابایت و رم 4 گیگابایت - نات اکتیو\r\n", 37000000 },
                    { 3, 1, "گوشی موبایلبدون هیچ تعریف اضافی باید بگوییم که گوشی‌های میان‌رده سری Redmi شرکت شیائومی توانسته‌اند عملکرد بسیار خوبی را به‌نمایش بگذارند. در این میان شاهد رونمایی برخی از محصولاتی بودیم که در برخی از مشخصات فنی در نظر گرفته شده چیزی کم از یک پرچمدار نداشتند. Redmi Note 12 4G هم یکی از این گوشی‌های هوشمند میان‌رده قدرتمند است که به نسبت قیمت در نظر گرفته شده، عملکرد بسیار خوبی را به‌نمایش گذاشته است. این گوشی به صفحه‌نمایش با ابعاد 6.67 اینچ و رزولوشن 1080×2400 پیکسل از نوع امولد مجهز ش ...\r\n", "گوشی موبایل شیائومی مدل Redmi Note 12 4G دو سیم کارت ظرفیت 128 گیگابایت و رم 8 گیگابایت - گلوبال\r\n", 10000000 },
                    { 4, 1, "با پیشرفت سریع فناوری هر روزه شاهد تولید گوشی‌های موبایل با قابلیت‌های جدید و منحصر به فرد هستیم. به طوری که برندهای معتبر برای به دست آوردن سهم بیشتر بازار به سختی در تکاپو هستند. از طرفی نوکیا سعی کرده از مورد دیگری برای فروش بیشتر کمک بگیرد؛ تجربه و نوستالژی، امتیازهایی هستند که تنها شرکت‌هایی به بزرگی نوکیا می‌توانند از آن‌ها برای فروش بیشتر استفاده کنند. تولید نسخه‌ی جدید از گوشی‌هایی که قبلا توسط نوکیا تولید شده بودند و البته با همان ن ...\r\n", "گوشی موبایل نوکیا مدل 2018 106 FA دو سیم‌ کارت ظرفیت 4 مگابایت و رم 4 مگابایت\r\n", 1000000 },
                    { 5, 2, "لپ تاپ 15.6 اینچی لنوو مدل IdeaPad 5 15ITL05 از محصولات سری «IdeaPad» شرکت «لنوو» محسوب می‌شود که با طراحی زیبا روانه‌ی بازار شده است. این لپ‌تاپ به‌واسطه‌ی قابلیت‌ها و امکاناتی که دارد، علاوه ‌بر کاربری معمول روزمره، برای کاربری مالتی‌مدیا هم مناسب است. بدنه‌ی شیک IdeaPad5 به‌گونه‌ای طراحی شده که لپ‌تاپی زیبا و باکیفیت را نوید می‌دهد. این بدنه 19.9 میلی‌متر ضخامت و 1.66 کیلوگرم وزن دارد و برای جابه‌جایی دائمی آن مشکل خاصی نخواهید داشت. صفحه‌نمایش 15.6 اینچی این محصول، پنل IP ...\r\n", "لپ تاپ 14 اینچی ایسوس مدل E410MA-EK1284\r\n", 12000000 },
                    { 6, 2, "لپتاپ 15.6 اینچی لنوو مدل IdeaPad 5 15ITL05، بدنه‌ای سبک و ظریف دارد و از نظر ظاهری از طراحی خاص و زیبایی برخوردار است. وزن این لپتاپ فقط 1.66 کیلوگرم است. تمام بدنه به‌جز پوشش آلومینیومی درب لپتاپ، تماما از جنس پلاستیک ABS است. یکی از مزیت‌های صفحه‌کلید لپتاپ داشتن نور پس‌زمینه است. نور پس‌زمینه کیبورد این امکان را به شما می‌دهد تا بتوانید حتی تاریکی با کلیدهای آن تایپ کنید. دکمه‌های این کیبورد پهن و ارتفاع آنها کوتاه است. تایپ کردن با این صفحه‌کلید، کاری لذت‌بخش و آسان است. تاچ‌پد آن هم فضای کافی برای حرکت نشان‌گر موس بر روی صفحه‌نمایش را دارد و به‌راحتی، انگشت شما روی آن حرکت می‌کند. ابعاد این تاچ‌پد، 10.5 سانتی‌متر طول در 7 سانتی‌متر عرض هستند. صفحه‌نمایش 15.6 اینچی لپتاپ مدل IdeaPad 5 15ITL05، از نوع FHD با رزولوشن 1920x1080 پیکسل است. پنل آن از نوع IPS و میزان روشنایی آن 300nits است. علاوه‌براین، پنل آن دارای یک لایه محافظ Anti-glare نیز هست که جلوی انعکاس نور را می‌گیرد. کیفیت این صفحه‌نمایش و میزان روشنایی آن بالاست و تنها ایرادی که می‌شود که به آن گرفت این است میزان طیف رنگی sRGB آن محدود و در حدود 36 درصد است. به‌علاوه، زاویه‌دید این صفحه‌نمایش ثابت است و شما می‌توانید از آن درمحیط باز نیز استفاده کنید. حاشیه‌های کناری آن باریک است و فضای زیادی را نیز دراختیار شما قرار می‌دهد. درمیانه حاشیه بالایی آن یک عدد دوربین وبکم 720p، مجهز به دکمه شاتر برای حفظ امنیت شما، وجود دارد.\r\n\r\n", "لپ تاپ 15.6 اینچی لنوو مدل IdeaPad 5 15ITL05-i5 8GB 512SSD MX450\r\n", 23000000 },
                    { 7, 2, "شرکت ایسوس از شرکت‌های شناخته شده در زمینه‌ی تولید قطعات کامپیوتر و لپ تاپ شناخته می‌شود. لپ تاپ‌های سری VivoBook این شرکت از محصولات پرفروش برای امور روزمره‌ی این شرکت هستند. لپ تاپ مدل VivoBook X515EP-EJ338 ایسوس از محصولات پرفروش این شرکت است که می‌تواند تمامی نیازهای دارندگانش از یک لپ تاپ مالتی مدیا را برطرف کند. این لپ تاپ به پردازنده‌ی مرکزی شرکت اینتل از سری Core i5 با مدل 1135G7 مجهز شده است. همچنین، 8 گیگابایت رم از نوع DDR4 در این لپ تاپ قرار دارد و علاوه بر آن، شا ...\r\n", "لپ تاپ 15.6 اینچی ایسوس مدل VivoBook X515EP-EJ338\r\n", 22000000 },
                    { 8, 2, "موردانتظارترین و تأثیرگذارترین رویداد اپل در سال 2020، نخستین کامپیوتر‌های مک با پردازنده‌ی اختصاصی این شرکت را به‌ارمغان آورد. مک‌بوک ایر نخستین لپ‌تاپ اپل با پردازنده‌ی مبتنی‌بر ARM کوپرتینونشین‌ها موسوم به M1 خواهد بود.همان‌طور که انتظار می‌رفت مک‌بوک ایر به‌لحاظ ظاهر و طراحی هیچ تفاوتی با نسخه‌ی اینتل ندارد و همانند گذشته است. تغییرات اصلی مک‌ بوک ایر در داخل آن رخ می‌دهد؛ جایی‌که تراشه اختصاصی M1 توان پردازشی موردنیاز کاربر را با بهره‌وری بالاتر و مصرف انرژی کمتر فراهم م ...\r\n", "لپ تاپ 13.3 اینچی اپل مدل MacBook Air MGN63 2020 LLA\r\n", 43000000 },
                    { 9, 3, "کامپیوتر فاطر مدل FSG-Full از قویترین مدل های موجود در بازار است که توسط برند فاطر تولید شده است. این سیستم از کیس حیرت انگیز فاطر مدل FG-800 بهره مند است که دارای ویژگی های بسیار زیادی میباشد. روی این مدل، مداربرد پیشرفته Z790 و دو عدد کارت گرافیک پرقدرت RTX4090 24GB GDDR6X نصب شده است که جمعا 48 گیگابایت حافظه اختصاصی نسل جدید GDDR6X را در اختیار قرار میدهد. وظیفه تامین انرژی مورد نیاز این سیستم توسط پاور پرقدرت سری بنز و حرفه ای 1650 واتی RM1650M فاطر تامین میگردد. همچنین ...\r\n", "کامپیوتر دسکتاپ فاطر مدل FSG-Full2\r\n", 396000000 },
                    { 10, 3, "کامپیوترهای دسکتاپ شرکت ام اس ای همواره به عنوان یکی از زیباترین و قدرتمندترین کامپیوترهای موجود در بازار شناخته می‌شوند. امروزه نسل جدیدی از این کامپیوترها با نام MEG Aegis Ti5 12VTJ عرضه شده است و به واسطه‌ی زیبایی ظاهری و قدرت خارق‌العاده‌اش می‌تواند هر گیمری را به سمت خود جذب کند. این کامپیوتر علاوه بر مشخصات ظاهری چشمگیر، از پردازنده‌ی مرکزی قدرتمند شرکت اینتل سری i9 و مدل 12900K بهره‌مند است. همچنین، شرکت ام اس آی برای این کامپیوتر میزان 128 گیگابایت رم DDR5 با سرعت فوق ...\r\n", "کامپیوتر دسکتاپ ام اس آی مدل MEG Aegis Ti5 12VTJ\r\n", 198000000 },
                    { 11, 3, "خب درسته این برند تو گیمینگ حرف اول رو میزنه ولی موقعی که خودت پارت انتخاب کنی یه نسل سیزده گیرت میاد و یه 4070 و با 1 ترا اس اس دی 990 پرو سامسونگ و 2 ترا اس اس دی ساتا gen 3\r\n\r\n", "کامپیوتر دسکتاپ الین ور مدل Aurora R13\r\n", 175000000 },
                    { 12, 3, "سیستم PC Gaming i3 9100f Code Pro301 در دسته کامپیوترهای گیمینگ و رندرینگ حرفه ای میباشد،این سیستم یکی از ارزانترین سیستمهای حرفه ای با قابلیت اجرای بیشتر نرم افزارهای طراحی و مهندسی و اجرای بیشتر بازیهای کامپیوتر سنگین و آنلاین و استریم میباشد. این سیستم دارای پردازنده Core i3 9100f و دارای 16 گیگ رم DDR4 و یکی هارد دیسک پر سرعت SSD با ظرفیت 256GB گیگابایت و دیگری نیز یک عدد هارد دیسک معمولی با ظرفیت 1 ترابایت برای ذخیره سازی اطلاعات دارد و کارت گرافیک پلیت GTX 1050TI 4GB ...\r\n", "کامپیوتر دسکتاپ مستر تک مدل PC Gaming i3 9100f Code Pro301\r\n", 28000000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
