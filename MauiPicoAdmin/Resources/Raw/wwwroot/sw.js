const STATIC_CACHE = "pico-static-v1";
const API_CACHE = "pico-api-v1";

const STATIC_FILES = [
    "/",
    "/index.html",
    "/product.html",
    "/ws.html",
    "/search.html"
];

self.addEventListener("install", event => {

    event.waitUntil(
        caches.open(STATIC_CACHE)
            .then(cache => cache.addAll(STATIC_FILES))
    );

});

self.addEventListener("activate", event => {

    event.waitUntil(
        caches.keys().then(keys => {
            return Promise.all(
                keys.filter(k => k !== STATIC_CACHE && k !== API_CACHE)
                    .map(k => caches.delete(k))
            );
        })
    );

});

self.addEventListener("fetch", event => {

    const url = new URL(event.request.url);

    // 商品 API
    if (url.pathname.startsWith("/api/product")) {

        event.respondWith(cacheProductApi(event.request));
        return;

    }

    // 静态资源
    event.respondWith(cacheFirst(event.request));

});

// 商品 API 缓存策略：先返回缓存，再更新缓存
async function cacheProductApi(request) {

    const cache = await caches.open(API_CACHE);

    const cached = await cache.match(request);

    const networkFetch = fetch(request)
        .then(response => {

            cache.put(request, response.clone());

            return response;

        })
        .catch(() => cached);

    return cached || networkFetch;

}

// 静态资源缓存策略：先返回缓存，若无则从网络获取并缓存
async function cacheFirst(request) {

    const cache = await caches.open(STATIC_CACHE);

    const cached = await cache.match(request);

    if (cached) return cached;

    const response = await fetch(request);

    cache.put(request, response.clone());

    return response;

}
