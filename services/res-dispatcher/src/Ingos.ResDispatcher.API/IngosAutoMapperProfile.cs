// -----------------------------------------------------------------------
// <copyright file= "AutoMapperProfile.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2022-02-04 15:23
// Modified by:
// Description: AutoMapper object mapper profile
// -----------------------------------------------------------------------

using AutoMapper;
using Ingos.ResDispatcher.API.Applications.Dtos;
using Ingos.ResDispatcher.API.Applications.Dtos.Deployments;
using k8s.Models;

namespace Ingos.ResDispatcher.API;

/// <summary>
///     AutoMapper object mapper profile
/// </summary>
public class IngosAutoMapperProfile : Profile
{
    /// <summary>
    ///     ctor
    /// </summary>
    public IngosAutoMapperProfile()
    {
        // Container
        CreateMap<V1Container, ContainerDto>()
            .ForMember(d => d.Image, o => o.MapFrom(s => s.Image));

        // Deployment
        CreateMap<V1Deployment, DeploymentDto>()
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Metadata.Name))
            .ForMember(d => d.Labels, o => o.MapFrom(s => s.Metadata.Labels))
            .ForMember(d => d.CreationTimestamp,
                o => o.MapFrom(s => Convert.ToDateTime(s.Metadata.CreationTimestamp).ToLocalTime()))
            .ForMember(d => d.Replicas, o => o.MapFrom(s => s.Spec.Replicas))
            .ForMember(d => d.Containers, o => o.MapFrom(s => s.Spec.Template.Spec.Containers));
    }
}