// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// ------------------------------------------------------------------------------
// Changes to this file must follow the https://aka.ms/api-review process.
// ------------------------------------------------------------------------------

namespace Microsoft.Extensions.Configuration
{
    public static partial class JsonConfigurationExtensions
    {
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddJsonFile(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, Microsoft.Extensions.FileProviders.IFileProvider? provider, string path, bool optional, bool reloadOnChange, string separator = ":") { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddJsonFile(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, System.Action<Microsoft.Extensions.Configuration.Json.JsonConfigurationSource>? configureSource, string separator = ":") { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddJsonFile(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, string path, string separator = ":") { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddJsonFile(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, string path, bool optional, string separator = ":") { throw null; }

        //todo: SD: need to add separate to rest of methods here.
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddJsonFile(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, string path, bool optional, bool reloadOnChange, string separator = ":") { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddJsonStream(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, System.IO.Stream stream, string separator = ":") { throw null; }
    }
}
namespace Microsoft.Extensions.Configuration.Json
{
    public partial class JsonConfigurationProvider : Microsoft.Extensions.Configuration.FileConfigurationProvider
    {
        public JsonConfigurationProvider(Microsoft.Extensions.Configuration.Json.JsonConfigurationSource source) : base (default(Microsoft.Extensions.Configuration.FileConfigurationSource)) { }
        public override void Load(System.IO.Stream stream, string separator = ":") { }
    }
    public partial class JsonConfigurationSource : Microsoft.Extensions.Configuration.FileConfigurationSource
    {
        public JsonConfigurationSource() { }
        public override Microsoft.Extensions.Configuration.IConfigurationProvider Build(Microsoft.Extensions.Configuration.IConfigurationBuilder builder) { throw null; }
        public string Separator { get; set; } = ":";
    }
    public partial class JsonStreamConfigurationProvider : Microsoft.Extensions.Configuration.StreamConfigurationProvider
    {
        public JsonStreamConfigurationProvider(Microsoft.Extensions.Configuration.Json.JsonStreamConfigurationSource source) : base (default(Microsoft.Extensions.Configuration.StreamConfigurationSource)) { }
        public override void Load(System.IO.Stream stream, string separator = ":") { }
    }
    public partial class JsonStreamConfigurationSource : Microsoft.Extensions.Configuration.StreamConfigurationSource
    {
        public JsonStreamConfigurationSource() { }
        public override Microsoft.Extensions.Configuration.IConfigurationProvider Build(Microsoft.Extensions.Configuration.IConfigurationBuilder builder) { throw null; }
    }
}
