using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;


// daha kolay yönetilebilir bir yapı oluşturmak için bu extensionları oluşturduk 

namespace Proje.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("sqlcon"),
                b => b.MigrationsAssembly("Proje"));

                options.EnableSensitiveDataLogging(true);//

            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;//Email kontrolü
                options.Password.RequireDigit = false;//Sifrede rakam olması gerekiyor
                options.Password.RequireLowercase = false;//Sifrede küçük harf olması gerekiyor
                options.Password.RequireUppercase = false;//Sifrede büyük harf olması gerekiyor
                options.Password.RequireNonAlphanumeric = true;//Sifrede non alfanumeric karakter olması gerekiyor
                options.Password.RequiredLength = 1;//Sifre uzunlugu

                // options.ClaimsIdentity.RoleClaimType = "Role";// Rol tipi
                // options.ClaimsIdentity.NameClaimType = "name"; //Ad tipi
                // options.ClaimsIdentity.EmailClaimType = "email";
                // options.ClaimsIdentity.UserIdClaimType = "user_id";
                // options.ClaimsIdentity.UserNameClaimType = "user_name";// Kullanici ad tipi 

                // options.User.RequireUniqueEmail = true;//Email kontrolü
                // options.User.RequireUniqueUsername = true;//Kullanici adı kontrolü
                // options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";//
                // options.User.RequirePhoneNumber = false;//Kullanici telefonu kontrolü
                // options.User.RequireEmail = true;//Kullanici email kontrolü
                // options.User.RequireConsent = false;// ne işe yarıyor?            
                // options.User.RequirePassword = true;//Sifre kontrolü
                // options.User.RequireEmailVerified = true;//Kullanici email onaylaması gerekiyor
                // options.User.RequirePhoneNumberVerified = false;//Kullanici telefonu onaylaması gerekiyor
                // options.User.RequirePasswordHash = true;//Sifre hashlemesi gerekiyor

                // options.User.RequireTwoFactorVerificationCode = false;//kurtarma kodu 
                // options.User.RequireTwoFactorRecoveryCode = false;// sms ile gelen kod 

                // options.Password.RequireDigit = true;//Sifrede rakam olması gerekiyor
                // options.Password.RequireLowercase = true;//Sifrede küçük harf olması gerekiyor
                // options.Password.RequireUppercase = true;//Sifrede büyük harf olması gerekiyor
                // options.Password.RequireNonAlphanumeric = true;//Sifrede non alfanumeric karakter olması gerekiyor
                // options.Password.RequiredLength = 8;//Sifre uzunlugu
                // options.Password.RequiredUniqueChars = 1;//Sifrede unique karakter olması gerekiyor

                // options.Lockout.MaxFailedAccessAttempts = 5;//Kullanici kaç kez kilitlenmesi gerekiyor
                // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);//Kullanici kilitlenmesinin istenmesi gerekiyor 
                // options.Lockout.AllowedForNewUsers = true; //Kullanici kilitlenmesinin istenmesi gerekiyor 

                // options.SignIn.RequireConfirmedEmail = true;//Kullanici email onaylaması gerekiyor
                // options.SignIn.RequireConfirmedPhoneNumber = false;//Kullanici telefonu onaylaması gerekiyor
                // options.SignIn.RequireConfirmedAccount = true;//Kullanici hesabı onaylaması gerekiyor

                // options.Tokens.EmailConfirmationTokenProvider = "";//Email onaylıyor
                // options.Tokens.PasswordResetTokenProvider = "";//Sifre degistiriliyor
                // options.Tokens.UserChangePasswordTokenProvider = "";//Sifre degistiriliyor
                // options.Tokens.TwoFactorRecoveryTokenProvider = "";//Kurtarma kodu
                // options.Tokens.RecoveryCodeTokenProvider = "";//Sifre degistiriliyor
                // options.Tokens.UserLockoutTokenProvider = ""; //Kullanici kilitlenmesi gerekiyor
                // options.Tokens.UserTokenProvider = "";//Kullanici tokeni
                // options.Tokens.ExternalProvider = "";//External Provider

                // options.Stores.MaxLengthForKeys = 128;//Kullanici ad ve parola uzunlukları
                // options.Stores.ProtectPersonalData = true;//Kullanici bilgileri saklamak için gerekiyor
                // options.Stores.SchemaVersion = 1;// kimlik doğrulama verileri veritanında saklanırken kullanılan şema sürümü

            }).AddEntityFrameworkStores<RepositoryContext>();
        }


        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession((options =>
            {
                options.Cookie.Name = "ProjeSession";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                // options.Cookie.HttpOnly = true;
                // options.Cookie.IsEssential = true;
            }));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static void ConfigureRepositorieRegistration(this IServiceCollection services)
        {
            services.AddTransient<IGirisRepository, GirisRepository>();
            services.AddTransient<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigureServiceManagerRegistration(this IServiceCollection services)
        {
            services.AddTransient<IGirisService, GirisManager>();
            services.AddTransient<IServiceManager, ServicesManager>();
        }






    }
}

