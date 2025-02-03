// MrBlit class definition
class MrBlit {
    constructor(apiUrl) {
        this._apiUrl = apiUrl;
        this.TimeOutOnSecond = 10;
    }

    async isExist(trainInfo) {
        const url = this.generateUrl(trainInfo);

        try {
            const response = await fetch(url, {
                    method: 'GET',
                    mode: 'no-cors',
                    timeout: this.TimeOutOnSecond * 1000 // Timeout in milliseconds
                }).catch((error) => {
                    const resultDivMrBlit = document.getElementById('mrBlitResultError');
                    resultDivMrBlit.innerHTML = "Error : " + error;
                    resultDivMrBlit.style.color = "black";
                    resultDivMrBlit.style.fontWeight = "normal";
                });

            if (response.ok) {
                const data = await response.json();

                if (data.Trains.some(train =>
                    train.Prices.some(price =>
                        price.Classes.some(cls => cls.Capacity > 0)
                    )
                )) {
                    return true;
                }
            }

            return false;
        } catch (error) {
            console.error("Error:", error);

            const resultDivMrBlit = document.getElementById('mrBlitResultError');
            resultDivMrBlit.innerHTML = "Error : " + error;
            resultDivMrBlit.style.color = "black";
            resultDivMrBlit.style.fontWeight = "normal";

            return false;
        }
    }

    generateUrl(trainInfo) {
        const params = new URLSearchParams({
            from: trainInfo.From,
            to: trainInfo.To,
            date: trainInfo.Date.toISOString().split('T')[0], // Format as yyyy-MM-dd
            genderCode: trainInfo.Gender,
            adultCount: trainInfo.AdultCount,
            childCount: trainInfo.ChildCount,
            infantCount: trainInfo.InfantCount,
            exclusive: trainInfo.Exclusive,
            availableStatus: trainInfo.AvailableStatus
        });

        return `${this._apiUrl}?${params.toString()}`;
    }
}

// Alibaba class definition
class Alibaba {
    constructor(apiUrl) {
        this._apiUrl = apiUrl;
        this.TimeOutOnSecond = 10;
    }

    async isExist(trainInfo) {
        const url = this.generateUrl(trainInfo);

        try {
            const response = await fetch(url, {
                method: 'GET',
                mode: 'no-cors',
                timeout: this.TimeOutOnSecond * 1000 // Timeout in milliseconds
            }).catch((error) => {
                const resultDivAlibaba = document.getElementById('alibabaResultError');
                resultDivAlibaba.innerHTML = "Error : " + error;
                resultDivAlibaba.style.color = "black";
                resultDivAlibaba.style.fontWeight = "normal";
            });

            if (response.ok) {
                const data = await response.json();

                if (data.result.departing.some(departure =>
                    departure.badges && departure.badges.length > 0
                )) {
                    return true;
                }
            }

            return false;
        } catch (error) {
            console.error("Error:", error);

            const resultDivAlibaba = document.getElementById('alibabaResultError');
            resultDivAlibaba.innerHTML = "Error : " + error;
            resultDivAlibaba.style.color = "black";
            resultDivAlibaba.style.fontWeight = "normal";

            return false;
        }
    }

    generateUrl(trainInfo) {
        const data = JSON.stringify(trainInfo);
        const hashed = btoa(data); // Base64 encoding
        return `${this._apiUrl}${hashed}`;
    }
}

function playAlertSound() {
    const audio = new Audio('beep.mp3');

    // Attempt to play and handle errors
    audio.play().catch(error => {
        console.error("Playback error:", error);
    });
}

// Infinite loop function to check train availability
async function checkTrainAvailability() {
    const mrBlit = new MrBlit('https://train.mrbilit.com/api/GetAvailable/v2');
    const alibaba = new Alibaba('https://ws.alibaba.ir/api/v2/train/available/');

    const trainInfoMrBlit = {
        From: 1,
        To: 37,
        Date: new Date('2025-02-06'),
        Gender: 3,
        AdultCount: 2,
        ChildCount: 0,
        InfantCount: 0,
        Exclusive: false,
        AvailableStatus: 'Both'
    };

    const trainInfoAlibaba = {
        From: 1,
        To: 37,
        DepartureDate: new Date('2025-02-06'),
        PassengerCount: 2
    };

    // Use a while loop to repeat the calls indefinitely
    let counter = 0; // Initialize a counter for API calls

    while (true) {
        // Increment counter on each API call
        counter++;

        const currentTime = new Date().toLocaleTimeString('en-GB', {hour12: false}); // Get the current time in 24-hour format

        // Check for availability on MrBlit
        const isAvailableMrBlit = await mrBlit.isExist(trainInfoMrBlit);
        const resultDivMrBlit = document.getElementById('mrBlitResult');

        if (isAvailableMrBlit) {
            // Set text to red and bold
            resultDivMrBlit.innerHTML = `شناسه: ${counter} زمان: ${currentTime} - موجود شد !!!`;
            resultDivMrBlit.style.color = "red";
            resultDivMrBlit.style.fontWeight = "bold";

            // Play a sound
            playAlertSound();

            // Change the background to red
            document.body.style.backgroundColor = "red";

            // Change the browser tab title
            document.title = "Train Available on MrBlit!";
        } else {
            resultDivMrBlit.innerHTML = `شناسه: ${counter} زمان: ${currentTime} - موجود نیست`;
            resultDivMrBlit.style.color = "black";
            resultDivMrBlit.style.fontWeight = "normal";
        }

        // Check for availability on Alibaba
        const isAvailableAlibaba = await alibaba.isExist(trainInfoAlibaba);
        const resultDivAlibaba = document.getElementById('alibabaResult');

        if (isAvailableAlibaba) {
            // Set text to red and bold
            resultDivAlibaba.innerHTML = `شناسه: ${counter} زمان: ${currentTime} - موجود شد !!!`;
            resultDivAlibaba.style.color = "red";
            resultDivAlibaba.style.fontWeight = "bold";

            // Play a sound
            playAlertSound();

            // Change the background to red
            document.body.style.backgroundColor = "red";

            // Change the browser tab title
            document.title = "Train Available on Alibaba!";
        } else {
            resultDivAlibaba.innerHTML = `شناسه: ${counter} زمان: ${currentTime} - موجود نیست`;
            resultDivAlibaba.style.color = "black";
            resultDivAlibaba.style.fontWeight = "normal";
        }

        // Log to console
        console.log(`Call #${counter} - Time: ${currentTime}`);

        // Wait for a certain interval (10 seconds) before checking again
        await new Promise(resolve => setTimeout(resolve, 10000)); // 10 seconds
    }


}

// Start the infinite loop
checkTrainAvailability();
