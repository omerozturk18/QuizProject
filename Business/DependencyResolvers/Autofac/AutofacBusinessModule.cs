﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.Mongo;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            //builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            //builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            //builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            //builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            //builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            //builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            //builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            //builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            //builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            //builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            //builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<QuizManager>().As<IQuizService>();
            builder.RegisterType<EfQuizDal>().As<IQuizDal>();
            builder.RegisterType<MongoQuizDal>().As<IMongoQuizDal>();


            builder.RegisterType<QuizTakerManager>().As<IQuizTakerService>();
            builder.RegisterType<MongoQuizTakerDal>().As<IMongoQuizTakerDal>();


            //builder.RegisterType<QuestionManager>().As<IQuestionService>();
            //builder.RegisterType<EfQuestionDal>().As<IQuestionDal>();

            //builder.RegisterType<QuestionOptionManager>().As<IQuestionOptionService>();
            //builder.RegisterType<EfQuestionOptionDal>().As<IQuestionOptionDal>(); 

            //builder.RegisterType<CustomerAnswerManager>().As<ICustomerAnswerService>();
            //builder.RegisterType<EfCustomerAnswerDal>().As<ICustomerAnswerDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
