package es.cifpcm.demoDB.controller;

import es.cifpcm.demoDB.data.servicios.AnimalService;
import es.cifpcm.demoDB.model.Animal;

import jakarta.validation.Valid;
import jakarta.validation.constraints.NotNull;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

@Validated
@RestController
@RequestMapping("/animal")
public class AnimalController {

    @Autowired
    private AnimalService animalService;

    @PostMapping
    public String save(@Valid @RequestBody Animal vO) {
        return animalService.save(vO).toString();
    }

    @DeleteMapping("/{id}")
    public void delete(@Valid @NotNull @PathVariable("id") Integer id) {
        animalService.delete(id);
    }

    @PutMapping("/{id}")
    public void update(@Valid @NotNull @PathVariable("id") Integer id,
                       @Valid @RequestBody Animal vO) {
        animalService.update(id, vO);
    }

    @GetMapping("/{id}")
    public Animal getById(@Valid @NotNull @PathVariable("id") Integer id) {
        return animalService.getById(id);
    }

    @GetMapping
    public Page<Animal> query(@Valid Animal vO) {
        return animalService.query(vO);
    }
}
