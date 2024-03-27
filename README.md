# DotNET Feature Flag Sample
DotNET Feature Flag sample written in ASP.NET Core &amp; Azure App Configuration/Azure Feature Management

## Author
Tea Binxiong

## Description
This repository demonstrate how to roll out a new feature in an ASP.NET Core web application to specified users and groups, using TargetingFilter with Azure App Configuration.

Targeting is a feature management strategy that enables developers to progressively roll out new features to their user base. The strategy is built on the concept of targeting a set of users known as the target audience. An audience is made up of specific users, groups, and a designated percentage of the entire user base.

The users can be actual user accounts, but they can also be machines, devices, or any uniquely identifiable entities to which you want to roll out a feature.

The groups are up to your application to define. For example, when targeting user accounts, you can use Microsoft Entra groups or groups denoting user locations. When targeting machines, you can group them based on rollout stages. Groups can be any common attributes based on which you want to categorize your audience. 

In this sample,  the signed-in user's email address is being used as the user ID, and the domain name portion of the email address as the group. You add the user and group to the TargetingContext. The TargetingFilter uses this context to determine the state of the feature flag for each request.

1. **UserTargetingContextAccesser**:
- [UserTargetingContextAccesser](./src/DotNET.FeatureFlagSample/Filters/)
   


## Repository URL
[dotnet-feature-flag](https://github.com/teabinxiong/dotnet-feature-flag)





