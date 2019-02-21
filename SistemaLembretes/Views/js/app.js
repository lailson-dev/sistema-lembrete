var app = new Vue({
    el: "#app",
    data: {
        title: "Seus Lembretes",
        success: false,
        error: false,
        empty: false,
        allLem: [],
        newLem: { Name: "", DatePublished: "" }
    },

    created() {
        this.getAllLem();
    },

    methods: {
        getAllLem() {
            let vm = this;

            axios.get('https://localhost:44306/api/getall')
                .then(res => {
                    vm.allLem = res.data;
                })
                .catch(e => {
                    console.log(e);
                });
        },

        createLem() {
            let vm = this;

            let data = {
                name: this.newLem.name,
                datePublished: this.newLem.datePublished
            };

            if (!data.name || !data.datePublished) {
                this.empty = true;
                return;
            }

            axios.post('https://localhost:44306/api/create', data)
                .then(res => {
                    if (res.status === 200) {
                        vm.success = true;
                        vm.getAllLem();
                        vm.clear();
                    }
                })
                .catch(e => {
                    vm.error = false;
                });
        },

        clear() {
            this.newLem.name = "";
            this.newLem.datePublished = "";
        }
    }
});