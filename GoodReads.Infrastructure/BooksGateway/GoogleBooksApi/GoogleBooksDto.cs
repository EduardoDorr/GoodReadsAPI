using System.Text.Json.Serialization;

namespace GoodReads.Infrastructure.BooksGateway.GoogleBooksApi;

public record GoogleBooksDto(
    [property: JsonPropertyName("kind")] string Kind,
    [property: JsonPropertyName("totalItems")] int TotalItems,
    [property: JsonPropertyName("items")] IReadOnlyList<Item> Items
);

public record AccessInfo(
    [property: JsonPropertyName("country")] string Country,
    [property: JsonPropertyName("viewability")] string Viewability,
    [property: JsonPropertyName("embeddable")] bool Embeddable,
    [property: JsonPropertyName("publicDomain")] bool PublicDomain,
    [property: JsonPropertyName("textToSpeechPermission")] string TextToSpeechPermission,
    [property: JsonPropertyName("epub")] Epub Epub,
    [property: JsonPropertyName("pdf")] Pdf Pdf,
    [property: JsonPropertyName("webReaderLink")] string WebReaderLink,
    [property: JsonPropertyName("accessViewStatus")] string AccessViewStatus,
    [property: JsonPropertyName("quoteSharingAllowed")] bool QuoteSharingAllowed
);

public record Epub(
    [property: JsonPropertyName("isAvailable")] bool IsAvailable,
    [property: JsonPropertyName("acsTokenLink")] string AcsTokenLink
);

public record ImageLinks(
    [property: JsonPropertyName("smallThumbnail")] string SmallThumbnail,
    [property: JsonPropertyName("thumbnail")] string Thumbnail
);

public record IndustryIdentifier(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("identifier")] string Identifier
);

public record Item(
    [property: JsonPropertyName("kind")] string Kind,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("etag")] string Etag,
    [property: JsonPropertyName("selfLink")] string SelfLink,
    [property: JsonPropertyName("volumeInfo")] VolumeInfo VolumeInfo,
    [property: JsonPropertyName("saleInfo")] SaleInfo SaleInfo,
    [property: JsonPropertyName("accessInfo")] AccessInfo AccessInfo,
    [property: JsonPropertyName("searchInfo")] SearchInfo SearchInfo
);

public record ListPrice(
    [property: JsonPropertyName("amount")] double Amount,
    [property: JsonPropertyName("currencyCode")] string CurrencyCode,
    [property: JsonPropertyName("amountInMicros")] int AmountInMicros
);

public record Offer(
    [property: JsonPropertyName("finskyOfferType")] int FinskyOfferType,
    [property: JsonPropertyName("listPrice")] ListPrice ListPrice,
    [property: JsonPropertyName("retailPrice")] RetailPrice RetailPrice,
    [property: JsonPropertyName("giftable")] bool Giftable
);

public record PanelizationSummary(
    [property: JsonPropertyName("containsEpubBubbles")] bool ContainsEpubBubbles,
    [property: JsonPropertyName("containsImageBubbles")] bool ContainsImageBubbles
);

public record Pdf(
    [property: JsonPropertyName("isAvailable")] bool IsAvailable,
    [property: JsonPropertyName("acsTokenLink")] string AcsTokenLink
);

public record ReadingModes(
    [property: JsonPropertyName("text")] bool Text,
    [property: JsonPropertyName("image")] bool Image
);

public record RetailPrice(
    [property: JsonPropertyName("amount")] double Amount,
    [property: JsonPropertyName("currencyCode")] string CurrencyCode,
    [property: JsonPropertyName("amountInMicros")] int AmountInMicros
);

public record SaleInfo(
    [property: JsonPropertyName("country")] string Country,
    [property: JsonPropertyName("saleability")] string Saleability,
    [property: JsonPropertyName("isEbook")] bool IsEbook,
    [property: JsonPropertyName("listPrice")] ListPrice ListPrice,
    [property: JsonPropertyName("retailPrice")] RetailPrice RetailPrice,
    [property: JsonPropertyName("buyLink")] string BuyLink,
    [property: JsonPropertyName("offers")] IReadOnlyList<Offer> Offers
);

public record SearchInfo(
    [property: JsonPropertyName("textSnippet")] string TextSnippet
);

public record SeriesInfo(
    [property: JsonPropertyName("kind")] string Kind,
    [property: JsonPropertyName("bookDisplayNumber")] string BookDisplayNumber,
    [property: JsonPropertyName("volumeSeries")] IReadOnlyList<VolumeSeries> VolumeSeries
);

public record VolumeInfo(
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("authors")] IReadOnlyList<string> Authors,
    [property: JsonPropertyName("publishedDate")] string PublishedDate,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("industryIdentifiers")] IReadOnlyList<IndustryIdentifier> IndustryIdentifiers,
    [property: JsonPropertyName("readingModes")] ReadingModes ReadingModes,
    [property: JsonPropertyName("pageCount")] int PageCount,
    [property: JsonPropertyName("printType")] string PrintType,
    [property: JsonPropertyName("categories")] IReadOnlyList<string> Categories,
    [property: JsonPropertyName("maturityRating")] string MaturityRating,
    [property: JsonPropertyName("allowAnonLogging")] bool AllowAnonLogging,
    [property: JsonPropertyName("contentVersion")] string ContentVersion,
    [property: JsonPropertyName("panelizationSummary")] PanelizationSummary PanelizationSummary,
    [property: JsonPropertyName("comicsContent")] bool ComicsContent,
    [property: JsonPropertyName("language")] string Language,
    [property: JsonPropertyName("previewLink")] string PreviewLink,
    [property: JsonPropertyName("infoLink")] string InfoLink,
    [property: JsonPropertyName("canonicalVolumeLink")] string CanonicalVolumeLink,
    [property: JsonPropertyName("publisher")] string Publisher,
    [property: JsonPropertyName("imageLinks")] ImageLinks ImageLinks,
    [property: JsonPropertyName("seriesInfo")] SeriesInfo SeriesInfo
);

public record VolumeSeries(
    [property: JsonPropertyName("seriesId")] string SeriesId,
    [property: JsonPropertyName("seriesBookType")] string SeriesBookType,
    [property: JsonPropertyName("orderNumber")] int OrderNumber
);