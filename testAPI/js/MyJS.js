class UseAPI {

    ListData(url, callback) {
        $.ajax({
            type: "Get",
            url: url,
            success: function (data) {
                callback(data);
            },
            error: function (resp) {

            }
        });
    };

    GetData(url, callback) {
        $.ajax({
            type: "Get",
            url: url,
            success: function (data) {
                callback(data);
            },
            error: function (resp) {

            }

        });
    };

    CreateData(url, jsonData, callback) {
        $.ajax({
            type: "Post",
            url: url,
            contentType: "application/json",
            data: jsonData,
            success: function (data) {
                callback(data);
            },
            error: function (resp) {

            }

        });
    };

    UpdateData(url, jsonData, callback) {
        $.ajax({
            type: "Put",
            url: url,
            contentType: "application/json",
            data: jsonData,
            success: function (data) {
                callback(data);
            },
            error: function (resp) {

            }

        });
    };

    DeleteData(url, callback) {
        $.ajax({
            type: "Delete",
            url: url,
            success: function (data) {
                callback(data);
            },
            error: function (resp) {

            }

        });
    };

};

// class UseAPIForTest {

//     ListData(url, callback) {
//         $.ajax({
//             type: "Get",
//             url: url,
//             success: function (data) {
//                 callback(data);
//             },
//             error: function (resp) {

//             }
//         });
//     };
// };

class UseAPIForTest {
    async ListData(baseUrl, top, skip, filter, callback) {
        try {
            const url = `${baseUrl}&$top=${top}&$skip=${skip}&$filter=${filter}`;
            // console.log(url)
            const response = await fetch(url, {
                method: 'GET',
            });

            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            const data = await response.json();
            const limitedData = [...data];
            // console.log(limitedData);

            callback(limitedData);
        } catch (error) {
            console.error("Error fetching data:", error);
        }
    }
}

