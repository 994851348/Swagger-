using System.Web.Http;
using WebActivatorEx;
using WebApplication;
using Swashbuckle.Application;
using System;
using System.Reflection;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApplication
{
    /// <summary>
    /// API��������
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// API�ĵ�����ע��
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            //��ȡ��Ŀ�ļ�·��
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\";
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        
                        c.SingleApiVersion("v1", "WebApplication");
                        c.IncludeXmlComments(commentsFile);
                    })
                .EnableSwaggerUi(c =>
                    {
                        //��������UI�����ϵĶ�����
                        //���غ�����js�ļ���ע�� swagger.js�ļ����Ա�������Ϊ��Ƕ�����Դ���� APIUI.Scripts.swagger.js�����ǣ���Ŀ����->�ļ���->js�ļ���
                        c.InjectJavaScript(Assembly.GetExecutingAssembly(), "WebApplication.Scripts.swagger.js");
                    });
        }
    }
}
