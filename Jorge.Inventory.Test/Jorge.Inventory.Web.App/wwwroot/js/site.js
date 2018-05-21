
function resolveUrl(url) {
    if (url.indexOf("~/") === 0) {
        url = baseUrl + url.substring(2);
    }
    return url;
}
