﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Airplane.Application.Messages {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MensagensAplicacao {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MensagensAplicacao() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Airplane.Application.Messages.MensagensAplicacao", typeof(MensagensAplicacao).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo {PropertyName} não pode ser maior do que a data atual..
        /// </summary>
        public static string CAMPO_DATA_MAIOR_QUE_HOJE {
            get {
                return ResourceManager.GetString("CAMPO_DATA_MAIOR_QUE_HOJE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo {PropertyName} é obrigatório!.
        /// </summary>
        public static string CAMPO_OBRIGATORIO {
            get {
                return ResourceManager.GetString("CAMPO_OBRIGATORIO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ocorreu um erro ao tentar validar os campos enviados, verifque os dados e tente novamente..
        /// </summary>
        public static string MENSAGEM_ERRO_VALIDACAO {
            get {
                return ResourceManager.GetString("MENSAGEM_ERRO_VALIDACAO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo {PropertyName} precisa ter {MaxLength} caracteres..
        /// </summary>
        public static string TAMANHO_ESPECIFICO_CAMPO {
            get {
                return ResourceManager.GetString("TAMANHO_ESPECIFICO_CAMPO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo {PropertyName} precisa ter no mínimo {MinLength} e no máximo {MaxLength} caracteres..
        /// </summary>
        public static string TAMANHO_INTERVALO_CAMPO {
            get {
                return ResourceManager.GetString("TAMANHO_INTERVALO_CAMPO", resourceCulture);
            }
        }
    }
}
