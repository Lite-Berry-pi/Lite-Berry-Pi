
'use strict';

import { signalR } from "./js/signalr/dist/browser/signalr";

var connection = new signalR.HubConnectionBuilder().withUrl("raspberrypi").build();

connection.on("ReceiveLiteBerry", (user, designCoords) => {
    // get the things
});

connection.start().then(() => {
    // 
});


connection.invoke("SendLiteBerry", user, designCoords)
    .catch((e) => console.error(e.toString()));
    