const DELAY = 500;
var call;

export let throttleFunc = (func) => {
    if (toString.apply(func) === "[object Function]") {
        if (!call) {
            call = func;
            startProcessing();
        } else {
            call = func;
        }
    }
}

let startProcessing = () => {
    setInterval(call, delay);
}
