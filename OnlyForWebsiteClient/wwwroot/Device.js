export function GetUA() {
    return navigator.userAgent;
}
export function GetNetwork(obj) {
    window.addEventListener("online", () => obj.invokeMethod("Online"))
    window.addEventListener("offline", () => obj.invokeMethod("Offline"))
    return navigator.onLine;
}
export function Console(v) {
    console.log(v);
}