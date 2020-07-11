import http from "../api/http-common";

export class ProductDataService {
    getAll() {
        return http.get("/product");
    }

    get(id) {
        return http.get(`/product/${id}`);
    }

    create(data) {
        return http.post("/product", data);
    }

    update(id, data) {
        return http.put(`/product/${id}`, data);
    }

    delete(id) {
        return http.delete(`/product/${id}`);
    }

    deleteAll() {
        return http.delete(`/product`);
    }

    findByModel(model) {
        return http.get(`/product?model=${model}`);
    }
}

