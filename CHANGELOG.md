## [3.0.0] - 03.09.2025

### Anytype.NET

- Renamed methods for consistency.
- Adjusted nullable return types for consistency across endpoints.
- Made properties in response models nullable/non-nullable according to the documentation.
- Aligned all request model properties with official API docs
- Refactored getting object by ID endpoint.
- Refactored TagRequest to CreateTagRequest and UpdateTagRequest.
- Refactored TypeRequest to CreateTypeRequest and UpdateTypeRequest.
- Refactored UpdateSpaceRequest.
- Renamed ObjectType property of Space class to Object.
- Added JsonPropertyName attributes to all model classes.
- Deleted PropertyFactory class.
- Added Email and Phone properties to the Property model.
- Fix: removed duplicate Tag class.
- Renamed AnyMember class to Member.
- Made ClientBase constructor private protected.
- Made the methods of ClientBase class private protected.
- Encapsulated all subclients, exposing only their interfaces
- Added Auth endpoints.

### Tests

- Added tests for SpacesClient.

### Demo

- Replaced API key retrieval with environment variable.
- Added Auth endpoints demo.

### Other

- Added docs for Spaces endpoints.
- Added docs for Members endpoints.
- Added docs for Objects endpoints.
- Added docs for Types endpoints.
- Added docs for Templates endpoints.
- Added docs for Properties endpoints.
- Added docs for Tags endpoints.
- Added docs for Search endpoints.
- Added docs for Lists endpoints.
- Added docs for Auth endpoints.
- Made categories in the README table clickable.


## [2.0.0] - 22.08.2025

### Anytype.NET
- Unified and corrected XML documentation for all endpoint clients.
- Removed method that returns a simplified list of spaces.
- Added README file to the NuGet package.

### Tests
- Added tests project (Anytype.NET.Tests) with first test for `SpacesClient.ListAsync`.

## [1.0.0] - 20.08.2025

- Initial release of Anytype.NET.