# Wpf.DependencyResolution
[![Build Status](https://travis-ci.com/mr-rampage/Wpf.DependencyResolution.svg?branch=master)](https://travis-ci.com/mr-rampage/Wpf.DependencyResolution)
[![Nuget](https://img.shields.io/nuget/v/Wpf.DependencyResolution)](https://www.nuget.org/packages/Wpf.DependencyResolution/)

The Dependency Resolution Protocol is a protocol used for dependency resolution using events. This protocol was presented at the talk below and ported to WPF by leveraging routed events. This implementation was mainly built to facilitate the use of the Flux pattern in WPF instead of the MVVM pattern.

[![Building a Complex Application with Web Components and LitElement](https://img.youtube.com/vi/x9YDQUJx2uw/0.jpg)](http://www.youtube.com/watch?v=x9YDQUJx2uw)

This implementation provides extensions that can be used with elements to allow elements to provide dependencies to all their decendants. However, when using this protocol, a dependency injection framework must be supplied and can be adapted to this protocol using the `IInjector` interface. This protocol allows for dependencies to be staggered through the component tree, which can allow for dependencies to be isolated within certain branches of the tree. However, for simplicity's sake, it's best to start out with a single root element that acts as the IoC container.

## Usage

1. Implement an injector with your favourite Dependency Injection framework by using the `IInjector` interface.
2. Call `ProvideInstance` on the injector in the Root element - ideally in the constructor.
3. Call `RequestInstance` on any decendant element to get the dependency.

## API

### IInjector interface

#### AddInstance

This method adds an instance to be tracked by the dependency injection framework. This should return the injector to allow for fluent chaining of dependencies when configuring the dependency injection framework.

#### ResolveInstance

This method returns the instance that matches the generic type provided by the caller.

### InstanceProvider extension

#### ProvideInstance

By calling this method within an element, the element will listen for any `RequestInstance` routed event and attempt to find the instance within its associated injector.

### InstanceRequester extension

#### RequestInstance

By calling this method within an element, the element will raise the `RequestInstance` routed event to request an instance from an ancestor element that is an `InstanceProvider`.
