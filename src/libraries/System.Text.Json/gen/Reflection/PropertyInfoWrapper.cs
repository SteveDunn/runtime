﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace System.Text.Json.Reflection
{
    internal class PropertyInfoWrapper : PropertyInfo
    {
        private readonly IPropertySymbol _property;
        private MetadataLoadContextInternal _metadataLoadContext;
        private bool _needsAtSign;

        public PropertyInfoWrapper(IPropertySymbol property, MetadataLoadContextInternal metadataLoadContext)
        {
            _property = property;
            _metadataLoadContext = metadataLoadContext;

            if (_property.DeclaringSyntaxReferences.Length > 0)
            {
                PropertyDeclarationSyntax paramSyntax = _property.DeclaringSyntaxReferences[0].GetSyntax() as PropertyDeclarationSyntax;
                if (paramSyntax != null && !string.IsNullOrEmpty(paramSyntax.Identifier.Text))
                {
                    _needsAtSign = paramSyntax.Identifier.Text[0] == '@';
                }
            }
        }

        public override PropertyAttributes Attributes => throw new NotImplementedException();

        public override bool CanRead => _property.GetMethod != null;

        public override bool CanWrite => _property.SetMethod != null;

        public override Type PropertyType => _property.Type.AsType(_metadataLoadContext);

        public override Type DeclaringType => _property.ContainingType.AsType(_metadataLoadContext);

        public override string Name => _property.Name;

        public bool NeedsAtSign => _needsAtSign;

        public override Type ReflectedType => throw new NotImplementedException();

        public override MethodInfo[] GetAccessors(bool nonPublic)
        {
            throw new NotImplementedException();
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotSupportedException();
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }

        public override IList<CustomAttributeData> GetCustomAttributesData()
        {
            var attributes = new List<CustomAttributeData>();
            foreach (AttributeData a in _property.GetAttributes())
            {
                attributes.Add(new CustomAttributeDataWrapper(a, _metadataLoadContext));
            }
            return attributes;
        }

        public override MethodInfo GetGetMethod(bool nonPublic)
        {
            return _property.GetMethod!.AsMethodInfo(_metadataLoadContext);
        }

        public override ParameterInfo[] GetIndexParameters()
        {
            var parameters = new List<ParameterInfo>();
            foreach (IParameterSymbol p in _property.Parameters)
            {
                parameters.Add(new ParameterInfoWrapper(p, _metadataLoadContext));
            }
            return parameters.ToArray();
        }

        public override MethodInfo GetSetMethod(bool nonPublic)
        {
            return _property.SetMethod!.AsMethodInfo(_metadataLoadContext);
        }

        public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public Location? Location => _property.Locations.Length > 0 ? _property.Locations[0] : null;
    }
}
