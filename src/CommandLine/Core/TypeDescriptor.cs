// Copyright 2005-2015 Giacomo Stelluti Scala & Contributors. All rights reserved. See License.md in the project root for license information.

using System;
using CSharpx;

namespace CommandLine.Core
{
    struct TypeDescriptor
    {
        private TypeDescriptor(TargetType targetType, Maybe<int> maxItems, Maybe<TypeDescriptor> nextValue = null)
        {
            this.TargetType = targetType;
            this.MaxItems = maxItems;
            this.NextValue = nextValue;
        }

        public TargetType TargetType { get; }

        public Maybe<int> MaxItems { get; }

        public Maybe<TypeDescriptor> NextValue { get; }

        public static TypeDescriptor Create(TargetType tag, Maybe<int> maximumItems, TypeDescriptor next = default(TypeDescriptor))
        {
            if (maximumItems == null) throw new ArgumentNullException(nameof(maximumItems));

            return new TypeDescriptor(tag, maximumItems, next.ToMaybe());
        }
    }

    static class TypeDescriptorExtensions
    {
        public static TypeDescriptor WithNextValue(this TypeDescriptor descriptor, Maybe<TypeDescriptor> nextValue)
        {
            return TypeDescriptor.Create(descriptor.TargetType, descriptor.MaxItems, nextValue.GetValueOrDefault(default(TypeDescriptor)));
        }
    }
}
